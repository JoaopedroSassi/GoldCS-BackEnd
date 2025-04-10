using GoldCS.Domain.Extensions;
using GoldCS.Domain.Interfaces;
using GoldCS.Domain.Models.Response;
using GoldCS.Domain.Repository.Interfaces;
using GoldCS.Domain.Models;
using GoldCS.Domain.Models.Request;
using Microsoft.Extensions.Configuration;

namespace GoldCS.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IWebTokenService _webTokenService;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IUserRepository userRepository, 
                                    IWebTokenService webTokenService, 
                                    IConfiguration configuration
            )
        {
            _userRepository = userRepository;
            _webTokenService = webTokenService;
            _configuration = configuration;
        }

        public async Task<BaseResponse<LoginResponse>> Authenticate(LoginRequest request)
        {
            var user = await _userRepository.FindUserByEmail(request.email);

            if (user == null)
            {
                return new BaseResponse<LoginResponse>().GerarCritica(Criticas.LOGININVALIDO);
            } 
                        
            if(!ValidateCredentials(request.password, user))
            {
                return new BaseResponse<LoginResponse>().GerarCritica(Criticas.CREDENCIAISINVALIDAS);
            }
                        
            if (!user.Active)
            {
                return new BaseResponse<LoginResponse>().GerarCritica(Criticas.USUARIOINATIVO);
            }

            return ReturnResponseLogin(user);
        }

        private bool ValidateCredentials(string password, User user)
        {
            return EncryptionExtension.ComparePassword(password, user.Password);
        }

        public BaseResponse<LoginResponse> ReturnResponseLogin(User user)
        {
            var expiresIn = _configuration.GetValue<int>("Jwt:expiresIn");
            var accessToken = _webTokenService.ObterToken(user, expiresIn);
            var refreshToken = Guid.NewGuid().ToString();

            return GenerateResponse(user, accessToken, refreshToken, expiresIn);
        }

        private BaseResponse<LoginResponse> GenerateResponse(User user, string accessToken, string refreshToken, int expiresIn)
        {
            var loggedUser = new LoggedUser
            {
                Email = user.Email,
                Name = user.Name,
                Id = user.UserId,
            };

            var loginResponse = new LoginResponse
            {
                access_token = accessToken,
                refresh_token = refreshToken,
                expiresIn = expiresIn,
                UserData = loggedUser
            };

            return new BaseResponse<LoginResponse>
            {
                Success = true,
                Result = loginResponse
            };
        }

    }
}
