using GoldCS.Domain.Models.Response;

namespace GoldCS.Domain.Interfaces.Services
{
    public interface IRefreshTokenService
    {
        Task<LoginResponse> Process(string request);

    }
}
