

using GoldCS.Domain.Models.Entities;

namespace GoldCS.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        public Task<Category> Get(int id);
        public Task<List<Category>> Get();

    }
}
