using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using src.Extensions;
using src.Models.DTO.OrderDTOS;
using src.Models.Entities;
using src.Repositories.Interfaces;
using src.Services.Interfaces;

namespace src.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
		private readonly IMapper _mapper;

		public OrderService(IOrderRepository orderRepository, IMapper mapper)
		{
			_orderRepository = orderRepository;
			_mapper = mapper;
		}

		public async Task<OrderDetailsDTO> GetOrderByIdAsync(int id)
		{
			var order = await _orderRepository.GetOrderByIdAsync(id);

			if (order is null)
				ExceptionExtensions.ThrowBaseException("Pedido não encontrado", HttpStatusCode.NotFound);

			return new OrderDetailsDTO(order);
		}

		public int InsertOrderAsync(OrderInsertDTO model)
		{
			//var orderDb = _mapper.Map<Order>(model);
			Order orderDb = new Order(model);
			
			_orderRepository.Insert(orderDb);
			if (!(_orderRepository.SaveChanges()))
				ExceptionExtensions.ThrowBaseException("Erro ao adicionar o pedido no banco de dados", HttpStatusCode.BadRequest);

			return orderDb.OrderID;
		}
	}
}