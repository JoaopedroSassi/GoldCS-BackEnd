using System.Text;
using src.Models.DTO.AddressDTOS;
using src.Models.DTO.ClientDTOS;
using src.Models.DTO.OrderProductDTOS;
using src.Models.Entities;

namespace src.Models.DTO.OrderDTOS
{
	public class OrderDetailsDTO
    {
        public int OrderID { get; set; }
		public DateTime OrderDate { get; set; }
		public string PaymentMethod { get; set; }
		public decimal Total { get; set; }
		public DateTime DeliveryForecast { get; set; }
		public string UserName { get; set; }
		public AddressDetailsDTO Address { get; set; }
		public ClientDetailsDTO Client { get; set; }
		public List<OrderProductDetailsDTO> OrderProducts { get; set; } = new();

		public OrderDetailsDTO(int orderID, DateTime orderDate, string paymentMethod, decimal total, DateTime deliveryForecast, string userName, AddressDetailsDTO address, ClientDetailsDTO client)
		{
			OrderID = orderID;
			OrderDate = orderDate;
			PaymentMethod = paymentMethod;
			Total = total;
			DeliveryForecast = deliveryForecast;
			UserName = userName;
			Address = address;
			Client = client;
		}

		public OrderDetailsDTO()
		{
		}

		public OrderDetailsDTO(Order model)
		{
			OrderID = model.OrderID;
			OrderDate = model.OrderDate;
			PaymentMethod = model.PaymentMethod;
			Total = model.Total;
			DeliveryForecast = model.DeliveryForecast;
			UserName = model.User.Name;
			Address = new AddressDetailsDTO(model.Address);
			Client = new ClientDetailsDTO(model.Client);
			OrderProducts = model.OrderProducts.Select(x => new OrderProductDetailsDTO(x)).ToList();
		}

		public override string ToString()
		{
			StringBuilder sb = new();
			sb.AppendLine($"Pedido N°{OrderID}");
			sb.AppendLine($"Data do pedido: {OrderDate.ToString("dd/MM/yyyy")}");
			sb.AppendLine($"Método de pagamento: {PaymentMethod}");
			sb.AppendLine($"Total: {Total}");
			sb.AppendLine($"Previsão de entrega: {DeliveryForecast.ToString("dd/MM/yyyy")}");
			sb.AppendLine($"Nome do cliente: {Client.Name}");
			sb.AppendLine($"CPF do cliente: {Client.Cpf}");
			sb.AppendLine($"Endereço do cliente: {Address.ToString()}");
			sb.AppendLine($"---------------------------------");
			sb.AppendLine($"Produtos do pedido:");
			for (int i = 0; i < OrderProducts.Count; i++)
			{
				sb.AppendLine($"Produto {i + 1}: {OrderProducts[i].ProductName}");
				sb.AppendLine($"Quantidade: {OrderProducts[i].Quantity}");
				sb.AppendLine($"Preço unitário: {OrderProducts[i].FinalPrice}");
				sb.AppendLine("");
			}
			
			return sb.ToString();
		}
	}
}