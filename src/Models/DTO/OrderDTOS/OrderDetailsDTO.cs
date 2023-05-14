using src.Entities.Models;
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
		public int UserID { get; set; }
		public string UserEmail { get; set; }
		public string UserName { get; set; }
		public Address Address { get; set; }
		public Client Client { get; set; }
		public List<OrderProduct> OrderProducts { get; set; } = new();

		public OrderDetailsDTO(int orderID, DateTime orderDate, string paymentMethod, decimal total, DateTime deliveryForecast, int userID, string userEmail, string userName, Address address, Client client)
		{
			OrderID = orderID;
			OrderDate = orderDate;
			PaymentMethod = paymentMethod;
			Total = total;
			DeliveryForecast = deliveryForecast;
			UserID = userID;
			UserEmail = userEmail;
			UserName = userName;
			Address = address;
			Client = client;
		}

		public OrderDetailsDTO()
		{
		}
	}
}