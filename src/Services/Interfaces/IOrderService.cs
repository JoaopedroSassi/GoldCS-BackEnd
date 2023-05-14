using src.Models.DTO.OrderDTOS;

namespace src.Services.Interfaces
{
	public interface IOrderService
    {
        int InsertOrderAsync(OrderInsertDTO model);
		Task<OrderDetailsDTO> GetOrderByIdAsync(int id);
    }
}