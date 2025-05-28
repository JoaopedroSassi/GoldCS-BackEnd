using GoldCS.Domain.Interfaces;
using GoldCS.Domain.Models.Response;
using GoldCS.Domain.Repository.Interfaces;
using GoldCS.Domain.Models;
using GoldCS.Domain.Models.Request;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace GoldCS.Domain.Services
{
    public class AuthenticationService : BaseValidationService<LoginResponse,LoginRequest>, IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebTokenService _webTokenService;
        private readonly IConfiguration _configuration;

        public AuthenticationService(
                        UserManager<ApplicationUser> userManager,
                        IWebTokenService webTokenService,
                        IConfiguration configuration,
                        INotificationService notificationService
            ) : base(notificationService)
        {
            _userManager = userManager;
            _webTokenService = webTokenService;
            _configuration = configuration;
        }

        public override async Task<LoginResponse> Process(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.userName);

            if (user == null)
            {
                AddMessage("Usuário não encontrado");
                return null;
            }

            var isValidPassword = await _userManager.CheckPasswordAsync(user, request.password);

            if (!isValidPassword)
            {
                AddMessage("Usuário ou senha incorretos");
                return null;
            }

            return ReturnResponseLogin(user);
        }

        public LoginResponse ReturnResponseLogin(ApplicationUser user)
        {
            var expiresIn = _configuration.GetValue<int>("Jwt:ExpiresInSeconds");
            var rtExpires = _configuration.GetValue<int>("Jwt:RefreshTokenExpiresIn");
            var accessToken = _webTokenService.ObterToken(user, expiresIn);
            var refreshToken = _webTokenService.GenerateRefreshToken(user, rtExpires);

            return GenerateResponse(user, accessToken, refreshToken, expiresIn);
        }

        private LoginResponse GenerateResponse(ApplicationUser user, string accessToken, string refreshToken, int expiresIn)
        {
            var loggedUser = new LoggedUser
            {
                Email = user.Email,
                Name = user.UserName,
                Id = user.Id,
            };

            return new LoginResponse
            {
                Access_token = accessToken,
                Refresh_token = refreshToken,
                ExpiresIn = expiresIn,
                UserData = loggedUser
            };
        }

    }
}
