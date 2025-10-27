using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Models.Request;

namespace GoldCS.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<Product>> Get();
        Task<Product> Get(int id);
        Task<List<Product>> GetFromCategory(int categoryId);
        Task Insert(ProductRequests.Insert request);
        Task InsertAmount(ProductRequests.InsertAmount request);
        Task Update(ProductRequests.Update request);
        Task Inactivate(ProductRequests.Inactivate request);
    }
}
