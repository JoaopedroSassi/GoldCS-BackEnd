using GoldCS.Domain.Interfaces;
using GoldCS.Domain.Interfaces.Repository;
using GoldCS.Domain.Interfaces.Services;
using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;

namespace GoldCS.Domain.Services
{
    public class CreateOrderService : BaseValidationService<CreateOrderResponse, OrderRequests.CreateOrder>, ICreateOrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IAdressRepository _adressRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnityOfWork _unityOfWork;

        private OrderRequests.CreateOrder _request;
        private Client Client;
        private Adress Adress;
        private List<OrderProduct> OrderProducts = [];
        private Order Order;

        public CreateOrderService(
            INotificationService notificationService,
            IProductRepository productRepository,
            IClientRepository clientRepository,
            IAdressRepository adressRepository,
            IOrderRepository orderRepository,
            IUnityOfWork unityOfWork) : base(notificationService)
        {
            _productRepository = productRepository;
            _clientRepository = clientRepository;
            _adressRepository = adressRepository;
            _orderRepository = orderRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<CreateOrderResponse> Process(OrderRequests.CreateOrder request)
        {
            _request = request;            
            
            if (await ExecuteValidationsAsync(new CreateOrderValidations(), request) is false) return null;

            
            Order = new Order(_request);

            await ValidateClient();
            await ValidateProducts();
            await Transact();
            return CreateResponse();
            
        }

        private async Task ValidateClient()
        {
            var client = await _clientRepository.GetClientByCpf(_request.Cpf);  
            
            if (client is null)
            {
                AddMessage("Cliente não localizado. Faça o cadastro do cliente antes de realizar um pedido.");
                return;
            }

            Client = client;
        }
        
        private async Task UpdateClientFromOrder()
        {
            Client.Cpf = _request.Cpf;
            Client.Email = _request.Email;
            Client.CellPhone = _request.Cellphone;
            Client.Phone = _request.Phone;
            Client.Name = _request.ClientName;
            Order.Client = Client;

            await _clientRepository.Update(Client);
        }
        
        private async Task EnsureAdress()
        {
            var adress = await _adressRepository.FindByCepAndClientId(_request.Cep, Client.Id);

            if (adress is null)
            {
                var newAdress = new Adress
                {
                    CEP = _request.Cep,
                    Logradouro = _request.Logradouro,
                    Bairro = _request.Bairro,
                    Complemento = _request.Complemento,
                    UF = _request.UF,
                    Cidade = _request.Cidade,
                    ClientId = Client.Id,
                    AdressType = _request.AdressType,
                    Numero = _request.Numero,
                };

                await _adressRepository.Insert(newAdress);                
                Order.Adress = newAdress;
                return;
            }

            Adress = adress;
            Adress.CEP = _request.Cep;
            Adress.Logradouro = _request.Logradouro;
            Adress.Bairro = _request.Bairro;
            Adress.Complemento = _request.Complemento;
            Adress.UF = _request.UF;
            Adress.Cidade = _request.Cidade;
            Adress.AdressType = _request.AdressType;
            Adress.Numero = _request.Numero;

            await _adressRepository.Update(Adress);
            
            Order.Adress = Adress;

        }

        private async Task ValidateProducts() 
        { 
            foreach (var product in _request.Products)
            {
                Product existing = await _productRepository.Get(product.ProductId);
                
                if (existing is null) 
                {
                    AddMessage($"Não foi encontrado produto com o id: {product.ProductId}");
                    return; 
                }
                
                if (ValidatePrices(product, existing) is false)
                {
                    AddMessage($"Preço inválido para o produto: {existing.Name} | Valor abaixo do mínimo");
                    return;
                }

                if (ValidateStock(product, existing) is true)
                {
                    AddMessage($"O produto {existing.Name} não tem estoque suficiente para o solicitado no pedido"); 
                    return;
                }

                var orderProduct = new OrderProduct
                {
                    Order = Order,
                    Product = existing,
                    ProductId = existing.Id,
                    Quantity = product.Quantity, 
                    UnitaryValue = product.UnitaryPrice, 
                    TotalValue = (product.Quantity * product.UnitaryPrice)
                };

                OrderProducts.Add(orderProduct);
            }

            Order.Products = OrderProducts;
            Order.Subtotal = OrderProducts.Sum(x => x.TotalValue);

        }

        private async Task Transact()
        {
            await _unityOfWork.IniciarTransacao();
            
            await EnsureAdress();
            await UpdateClientFromOrder();
            await SensibilizeProductStock();         
            await _orderRepository.Insert(Order);
            await _unityOfWork.Commit();
        }

        private async Task SensibilizeProductStock()
        {
            foreach (var product in OrderProducts)
            {
                var productEntity = await _productRepository.Get(product.Product.Id);
                productEntity.Stock -= product.Quantity; 
                await _productRepository.Update(productEntity);
            }
        }

        private CreateOrderResponse CreateResponse()
        {
            return new CreateOrderResponse()
            {
                CreatedAt= Order.CreatedAt,
                Status = Order.Status.ToString(),
                Id = Order.Id,
            };
        }

        private bool ValidatePrices(OrderRequests.OrderProducts requestProduct, Product existingProduct)
        {
            return existingProduct.CostPrice < requestProduct.UnitaryPrice;  
        }
        private bool ValidateStock(OrderRequests.OrderProducts requestProduct, Product existingProduct)
        {
            return  existingProduct.Stock - requestProduct.Quantity < 0;
        }
    }
}
