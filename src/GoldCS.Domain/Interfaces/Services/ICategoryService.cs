

using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;

namespace GoldCS.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        public Task<CategoryResponse> Get(int id);
        public Task<List<CategoryResponse>> Get();
        Task Insert(CategoryRequests.Create request);
        Task Update(CategoryRequests.Alter request);
        Task Inactivate(CategoryRequests.Deactivate request);

    }
}
