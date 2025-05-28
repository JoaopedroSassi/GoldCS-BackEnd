using GoldCS.Domain.Interfaces;
using GoldCS.Domain.Models;
using GoldCS.Domain.Models.Response;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldCS.Domain.Services
{
    public class RefreshTokenService : BaseValidationService<LoginResponse, string>, IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthenticationService _authenticationService;
        public RefreshTokenService(
            INotificationService notificationService,
            IRefreshTokenRepository refreshTokenRepository,
            UserManager<ApplicationUser> userManager,
            IAuthenticationService authenticationService) : base(notificationService)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userManager = userManager;
            _authenticationService = authenticationService;
        }
        public override async Task<LoginResponse> Process(string request)
        {
            if(!Guid.TryParse(request, out var tokenId))
            {
                AddMessage("Refresh token inválido.");
                return null; 
            }

            var refreshToken = await _refreshTokenRepository.ObterRefreshToken(tokenId); 
            
            if (refreshToken is null)
            {
                AddMessage("Refresh token expirado.");
                return null;
            }

            var user = await _userManager.FindByNameAsync(refreshToken.UserName);
            
            return _authenticationService.ReturnResponseLogin(user);
        }
    }
}
