using GoldCS.Domain.Models;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;


namespace GoldCS.Domain.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<LoginResponse> Process(LoginRequest request);
        public LoginResponse ReturnResponseLogin(ApplicationUser user);

    }
}
