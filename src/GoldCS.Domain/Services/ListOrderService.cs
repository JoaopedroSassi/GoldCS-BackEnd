using GoldCS.Domain.Interfaces.Repository;
using GoldCS.Domain.Interfaces.Services;
using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Models.Response;

namespace GoldCS.Domain.Services
{
    public class ListOrderService : BaseValidationService, IListOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public ListOrderService (INotificationService notificationService,
                                 IOrderRepository orderRepository) : base(notificationService)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderResponse>> ListOrders()
        {
            var ret = await _orderRepository.GetAll();

            if (ret is null)
            {
                return []; 
            }

            var response = ret.Select(order => new OrderResponse
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                DeliveryDate = order.DeliveryDate,
                UserName = order.UserName,
                Status = order.Status.ToString(),
                Subtotal = order.Subtotal,
                PaymentMethod = order.PaymentMethod,
                ClientId = order.ClientId,
                AdressType = order.Adress.AdressType.ToString(),
                Bairro = order.Adress.Bairro,
                CEP = order.Adress.CEP,
                Logradouro = order.Adress.Logradouro,
                Numero = order.Adress.Numero,
                Cidade = order.Adress.Cidade,
                Complemento = order.Adress.Complemento,
                UF = order.Adress.UF,
                CellPhone = order.Client.CellPhone,
                ClientCpf = order.Client.Cpf,
                ClientEmail = order.Client.Email,
                ClientName = order.Client.Name,
                Phone = order.Client.Phone,
                Products = order.Products?.Select(p => new OrderProductsResponse
                {
                    ProductID = p.Product.Id,
                    ProductName = p.Product.Name,
                    UnitaryValue = p.UnitaryValue,
                    Quantity = p.Quantity,
                    TotalValue = p.TotalValue
                }).ToList() ?? []
            }).ToList();

            return response;
        }

        public async Task<OrderResponse> ViewOrder(int orderId)
        {
            var order = await _orderRepository.GetOrder(orderId);

            if (order is null)
            {
                AddMessage($"Nenhum pedido encontrado com o código de pedido: {orderId}");
                return null;
            }

            var response = new OrderResponse
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                DeliveryDate = order.DeliveryDate,
                UserName = order.UserName,
                Status = order.Status.ToString(),
                Subtotal = order.Subtotal,
                PaymentMethod = order.PaymentMethod,
                ClientId = order.ClientId,
                AdressType = order.Adress.AdressType.ToString(),
                Bairro = order.Adress.Bairro,
                CEP = order.Adress.CEP,
                Logradouro = order.Adress.Logradouro,
                Numero = order.Adress.Numero,
                Cidade = order.Adress.Cidade,
                Complemento = order.Adress.Complemento,
                UF = order.Adress.UF,
                CellPhone = order.Client.CellPhone,
                ClientCpf = order.Client.Cpf,
                ClientEmail = order.Client.Email,
                ClientName = order.Client.Name,
                Phone = order.Client.Phone,
                Products = order.Products?.Select(p => new OrderProductsResponse
                {
                    ProductID = p.Product.Id,
                    ProductName = p.Product.Name,
                    UnitaryValue = p.UnitaryValue,
                    Quantity = p.Quantity,
                    TotalValue = p.TotalValue
                }).ToList() ?? []
            };

            return response;
        }
    }
}
