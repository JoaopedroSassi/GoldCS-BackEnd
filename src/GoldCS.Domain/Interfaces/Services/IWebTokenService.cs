using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Models.Response;

namespace GoldCS.Domain.Interfaces.Services
{
    public interface IWebTokenService
    {
        string ObterToken(ApplicationUser user, int expiresIn);
        string GenerateRefreshToken(ApplicationUser user, int expiresIn);
    }
}
