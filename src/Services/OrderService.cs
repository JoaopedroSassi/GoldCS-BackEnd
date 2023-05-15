using System.Net;
using src.Extensions;
using src.Models.DTO.OrderDTOS;
using src.Models.Entities;
using src.Repositories.Interfaces;
using src.Services.Interfaces;
using src.Models.DTO.ProductDTOS;

namespace src.Services
{
	public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
		private readonly IProductService _productService;

		public OrderService(IOrderRepository orderRepository, IProductService productService = null)
		{
			_orderRepository = orderRepository;
			_productService = productService;
		}

		public async Task<OrderDetailsDTO> GetOrderByIdAsync(int id)
		{
			var order = await _orderRepository.GetOrderByIdAsync(id);

			if (order is null)
				ExceptionExtensions.ThrowBaseException("Pedido não encontrado", HttpStatusCode.NotFound);

			return new OrderDetailsDTO(order);
		}

		public async Task<int> InsertOrderAsync(OrderInsertDTO model)
		{
			Order orderDb = new Order(model);
			
			_orderRepository.Insert(orderDb);
			if (!(_orderRepository.SaveChanges()))
				ExceptionExtensions.ThrowBaseException("Erro ao adicionar o pedido no banco de dados", HttpStatusCode.BadRequest);

			/*for (int i = 0; i < model.OrderProducts.Count; i++)
				await _productService.RemoveAmountProductAsync(new ProductAmountRemoveDTO(model.OrderProducts[i]));
			
			if (!(await _orderRepository.SaveChangesAsync()))
				ExceptionExtensions.ThrowBaseException($"Erro ao remover estoque dos produtos no banco de dados", HttpStatusCode.BadRequest);*/
			
			return orderDb.OrderID;
		}
	}
}
