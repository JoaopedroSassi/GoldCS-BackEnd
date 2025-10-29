using GoldCS.Domain.Models.Entities;

namespace GoldCS.Domain.Interfaces.Repository
{
    public interface IOrderRepository
    {
        Task Insert(Order order);
        Task Update(Order order);
    }
}
