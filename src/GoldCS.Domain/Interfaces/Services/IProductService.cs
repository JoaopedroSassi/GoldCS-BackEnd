using GoldCS.Domain.Models.Entities;

namespace GoldCS.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetFromCategory(int categoryId); 
    }
}
