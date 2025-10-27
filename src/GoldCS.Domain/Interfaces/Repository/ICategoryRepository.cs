using GoldCS.Domain.Models.Entities;

namespace GoldCS.Domain.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> Get();
        Task<Category> Get(int id);
        Task Insert (Category category);
        Task Update (Category category);
        Task Inactivate (int id);
    }
}
