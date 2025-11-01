using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;

namespace GoldCS.Domain.Interfaces.Services
{
    public interface ICreateOrderService
    {
        Task<CreateOrderResponse> Process(OrderRequests.CreateOrder request); 
    }
}
