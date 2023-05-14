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
			var orderDB = await _orderRepository.GetOrderByIdAsync(id);
			var orderDetails = _mapper.Map<OrderDetailsDTO>(orderDB);

			throw new NotImplementedException();
		}

		public async Task InsertOrderAsync(OrderInsertDTO model)
		{
			//var orderDb = _mapper.Map<Order>(model);
			Order orderDb = new Order(model);
			
			_orderRepository.Insert(orderDb);
			if (!(await _orderRepository.SaveChangesAsync()))
				ExceptionExtensions.ThrowBaseException("Erro ao adicionar o pedido no banco de dados", HttpStatusCode.BadRequest);
		}
	}
}