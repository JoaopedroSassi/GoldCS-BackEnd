using GoldCS.Domain.Models.Request;
using Microsoft.AspNetCore.Identity;

namespace GoldCS.Domain.Interfaces.Services
{
    public interface ICreateUserService
    {
        Task<IdentityResult> Process(CreateUserRequest request);
    }
}
