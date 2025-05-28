using GoldCS.Domain.Models.Response;

namespace GoldCS.Domain.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<LoginResponse> Process(string request);

    }
}
