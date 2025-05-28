using GoldCS.Domain.Models.Request;
using Microsoft.AspNetCore.Identity;

namespace GoldCS.Domain.Interfaces
{
    public interface ICreateUserService
    {
        Task<IdentityResult> Process(CreateUserRequest request);
    }
}
