using GoldCS.Domain.Models.Entities;

namespace GoldCS.Domain.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetFromCategory(int categoryId);
    }
}
