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
		public int UserID { get; set; }
		public string UserEmail { get; set; }
		public string UserName { get; set; }
		public AddressDetailsDTO Address { get; set; }
		public ClientDetailsDTO Client { get; set; }
		public List<OrderProductDetailsDTO> OrderProducts { get; set; } = new();

		public OrderDetailsDTO(int orderID, DateTime orderDate, string paymentMethod, decimal total, DateTime deliveryForecast, int userID, string userEmail, string userName, AddressDetailsDTO address, ClientDetailsDTO client)
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

		public OrderDetailsDTO(Order model)
		{
			OrderID = model.OrderID;
			OrderDate = model.OrderDate;
			PaymentMethod = model.PaymentMethod;
			Total = model.Total;
			DeliveryForecast = model.DeliveryForecast;
			UserID = model.User.UserID;
			UserEmail = model.User.Email;
			UserName = model.User.Name;
			Address = new AddressDetailsDTO(model.Address);
			Client = new ClientDetailsDTO(model.Client);
			for (int i = 0; i < model.OrderProducts.Count; i++)
				OrderProducts.Add(new OrderProductDetailsDTO(model.OrderProducts[i]));
		}
	}
}