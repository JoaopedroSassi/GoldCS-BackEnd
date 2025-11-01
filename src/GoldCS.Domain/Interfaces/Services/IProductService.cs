using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;

namespace GoldCS.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<ProductResponse>> Get();
        Task<ProductResponse> Get(int id);
        Task<List<ProductResponse>> GetFromCategory(int categoryId);
        Task Insert(ProductRequests.Insert request);
        Task InsertAmount(ProductRequests.InsertAmount request);
        Task Update(ProductRequests.Update request);
        Task Inactivate(ProductRequests.Inactivate request);
    }
}
