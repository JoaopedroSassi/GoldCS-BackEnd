using System.Net;
using src.Extensions;
using src.Models.DTO.OrderDTOS;
using src.Models.Entities;
using src.Repositories.Interfaces;
using src.Services.Interfaces;
using src.Models.DTO.ProductDTOS;
using src.Entities.Models;
using src.Pagination;

namespace src.Services
{
	public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
		private readonly IProductService _productService;
		private readonly IClientRepository _clientRepository;
		private readonly IAddressRepository _addressRepository;

		public OrderService(IOrderRepository orderRepository, IProductService productService, IClientRepository clientRepository, IAddressRepository addressRepository)
		{
			_orderRepository = orderRepository;
			_productService = productService;
			_clientRepository = clientRepository;
			_addressRepository = addressRepository;
		}

		public async Task<OrderDetailsDTO> GetOrderByIdAsync(int id)
		{
			var order = await _orderRepository.GetOrderByIdAsync(id);

			if (order is null)
				ExceptionExtensions.ThrowBaseException("Pedido não encontrado", HttpStatusCode.NotFound);

			return new OrderDetailsDTO(order);
		}

		public async Task<PagedList<OrderDetailsDTO>> GetAllOrdersAsync(QueryPaginationParameters paginationParameters)
		{
			var fetchOrders = await _orderRepository.GetAllOrdersAsync(paginationParameters);
			var orders = fetchOrders.Select(x => new OrderDetailsDTO(x)).ToList();

            if (!orders.Any())
                ExceptionExtensions.ThrowBaseException("Nenhum pedido encontrado", HttpStatusCode.NotFound);

            return new PagedList<OrderDetailsDTO>(orders, _orderRepository.Count<Order>(), paginationParameters.PageNumber, paginationParameters.PageSize);
        }

		public async Task<int> InsertOrderAsync(OrderInsertDTO model)
		{
			if (model.DeliveryForecast < DateTime.Now)			
                ExceptionExtensions.ThrowBaseException("Data de entrega menor que a data atual", HttpStatusCode.BadRequest);
            
            Order orderDb = new Order(model);

			Client client = await _clientRepository.GetClientByCPFAsync(model.Client.Cpf);
			if (!(client is null))
			{
				Client clientUpdt = new Client(model.Client);
				clientUpdt.ClientID = client.ClientID;
				_clientRepository.Update(clientUpdt);
				
				orderDb.ClientID = client.ClientID;
				orderDb.Client = null;
			}

			Address address = await _addressRepository.GetAddressByCep(model.Address.Cep);
			if (!(address is null))
			{
				Address addressUpdt = new Address(model.Address);
				addressUpdt.AddressID = address.AddressID;
				_addressRepository.Update(addressUpdt);

				orderDb.AddressID = address.AddressID;
				orderDb.Address = null;
			}
			
			_orderRepository.Insert(orderDb);
			for (int i = 0; i < model.OrderProducts.Count; i++)
			{
				await _productService.VerifyPriceProduct(model.OrderProducts[i]);
				await _productService.RemoveAmountProductsAsync(new ProductAmountRemoveDTO(model.OrderProducts[i]));
			}
				
			if (!(_orderRepository.SaveChanges()))
				ExceptionExtensions.ThrowBaseException("Erro ao adicionar o pedido no banco de dados", HttpStatusCode.BadRequest);

			return orderDb.OrderID;
		}

		public async Task DeleteOrderAsync(int id)
		{
			Order order = await _orderRepository.GetOrderByIdAsync(id);

			if (order is null)
				ExceptionExtensions.ThrowBaseException("Pedido não encontrado", HttpStatusCode.NotFound);

			for (int i = 0; i < order.OrderProducts.Count; i++)
				await _productService.InsertAmountProductAsync(new ProductAmountInsertDTO(order.OrderProducts[i]));
			
			_orderRepository.Delete(order);
			if (!(await _orderRepository.SaveChangesAsync()))
				ExceptionExtensions.ThrowBaseException("Erro ao remover o pedido no banco de dados", HttpStatusCode.BadRequest);
		}
	}
}
