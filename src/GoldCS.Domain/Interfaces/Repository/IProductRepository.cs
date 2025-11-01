using GoldCS.Domain.Models.Entities;

namespace GoldCS.Domain.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> Get();
        Task<Product> Get(int id);
        Task<List<Product>> GetFromCategory(int categoryId);
        Task Insert(Product product);
        Task InsertAmount(int amountToAdd, Product product);
        Task Update(Product product);
        Task Inactivate(int id);
    }
}
