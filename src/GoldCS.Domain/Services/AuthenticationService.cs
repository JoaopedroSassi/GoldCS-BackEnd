using GoldCS.Domain.Extensions;
using GoldCS.Domain.Interfaces;
using GoldCS.Domain.Models.Response;
using GoldCS.Domain.Repository.Interfaces;
using GoldCS.Domain.Models;
using GoldCS.Domain.Models.Request;

namespace GoldCS.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IWebTokenService _webTokenService;
        public AuthenticationService(IUserRepository userRepository, 
                                    IWebTokenService webTokenService
            )
        {
            _userRepository = userRepository;
            _webTokenService = webTokenService;
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

            return _webTokenService.ReturnResponseLogin(user);
        }

        private bool ValidateCredentials(string password, User user)
        {
            return EncryptionExtension.ComparePassword(password, user.Password);
        }

    }
}
