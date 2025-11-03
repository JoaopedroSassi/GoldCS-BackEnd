using GoldCS.Domain.Models.Entities;

namespace GoldCS.Domain.Interfaces.Repository
{
    public interface IRefreshTokenRepository
    {
        Task SaveRefreshToken(RefreshToken refreshToken);
        Task<RefreshToken> ObterRefreshToken(Guid refreshToken);
    }
}
