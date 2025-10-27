

using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Models.Request;

namespace GoldCS.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        public Task<Category> Get(int id);
        public Task<List<Category>> Get();
        Task Insert(CategoryRequests.Create request);
        Task Update(CategoryRequests.Alter request);
        Task Inactivate(CategoryRequests.Deactivate request);

    }
}
