using GoldCS.Domain.Models.Request;

namespace GoldCS.Domain.Interfaces.Services
{
    public interface ICreateOrderService
    {
        Task Process(OrderRequests.CreateOrder request); 
    }
}
