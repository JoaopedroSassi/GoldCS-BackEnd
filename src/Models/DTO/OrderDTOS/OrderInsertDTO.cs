using src.Entities.DTO.ClientDTOS;
using src.Models.DTO.AddressDTOS;
using src.Models.DTO.OrderProductDTOS;

namespace src.Models.DTO.OrderDTOS
{
	public class OrderInsertDTO
	{
		public string PaymentMethod { get; set; }
		public decimal Total { get; set; }
		public DateTime DeliveryForecast { get; set; }
		public ClientInsertDTO Client { get; set; }
		public AddressInsertDTO Address { get; set; }
		public int UserID { get; set; }
		public List<OrderProductInsertDTO> OrderProducts { get; set; } = new();

		public OrderInsertDTO(string paymentMethod, decimal total, DateTime deliveryForecast, ClientInsertDTO client, AddressInsertDTO address, int userID, List<OrderProductInsertDTO> orderProducts)
		{
			PaymentMethod = paymentMethod;
			Total = total;
			DeliveryForecast = deliveryForecast;
			Client = client;
			Address = address;
			UserID = userID;
			OrderProducts = orderProducts;
		}

		public OrderInsertDTO()
		{
		}
	}
}