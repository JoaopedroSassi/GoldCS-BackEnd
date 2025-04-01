using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;


namespace GoldCS.Domain.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<LoginResponse> Authenticate(LoginRequest request);
    }
}
