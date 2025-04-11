using GoldCS.Domain.Interfaces;
using GoldCS.Domain.Models.Response;
using GoldCS.Domain.Repository.Interfaces;
using GoldCS.Domain.Models;
using GoldCS.Domain.Models.Request;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace GoldCS.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebTokenService _webTokenService;
        private readonly IConfiguration _configuration;

        public AuthenticationService(
                        UserManager<ApplicationUser> userManager,
                        IWebTokenService webTokenService,
                        IConfiguration configuration
            )
        {
            _userManager = userManager;
            _webTokenService = webTokenService;
            _configuration = configuration;
        }

        public async Task<BaseResponse<LoginResponse>> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.userName);

            if (user == null)
            {
                return new BaseResponse<LoginResponse>().GerarCritica(Criticas.LOGININVALIDO);
            }

            var isValidPassword = await _userManager.CheckPasswordAsync(user, request.password);

            if (!isValidPassword)
            {
                return new BaseResponse<LoginResponse>().GerarCritica(Criticas.CREDENCIAISINVALIDAS);
            }

            return ReturnResponseLogin(user);
        }

        public BaseResponse<LoginResponse> ReturnResponseLogin(ApplicationUser user)
        {
            var expiresIn = _configuration.GetValue<int>("Jwt:ExpiresIn");
            var accessToken = _webTokenService.ObterToken(user, expiresIn);
            var refreshToken = Guid.NewGuid().ToString();

            return GenerateResponse(user, accessToken, refreshToken, expiresIn);
        }

        private BaseResponse<LoginResponse> GenerateResponse(ApplicationUser user, string accessToken, string refreshToken, int expiresIn)
        {
            var loggedUser = new LoggedUser
            {
                Email = user.Email,
                Name = user.UserName,
                Id = user.Id,
            };

            var loginResponse = new LoginResponse
            {
                Access_token = accessToken,
                Refresh_token = refreshToken,
                ExpiresIn = expiresIn,
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
