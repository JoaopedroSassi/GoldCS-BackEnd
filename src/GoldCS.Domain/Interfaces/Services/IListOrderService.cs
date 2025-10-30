using GoldCS.Domain.Models.Response;

namespace GoldCS.Domain.Interfaces.Services
{
    public interface IListOrderService
    {
        Task<List<OrderResponse>> ListOrders(); 
        Task<OrderResponse> ViewOrder(int orderId);
    }
}
