using GoldCS.Domain.Models;

namespace GoldCS.Domain.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task SaveRefreshToken(RefreshToken refreshToken);
        Task<RefreshToken> ObterRefreshToken(Guid refreshToken);
    }
}
