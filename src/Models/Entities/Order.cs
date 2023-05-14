using src.Entities.Models;

namespace src.Models.Entities
{
	public class Order
    {
        public int OrderID { get; set; }
		public DateTime OrderDate { get; set; }
		public string PaymetMethod { get; set; }
		public decimal Total { get; set; }
		public DateTime DeliveryForecast { get; set; }
		public User User { get; set; }
		public int UserID { get; set; }
		public Client Client { get; set; }
		public int ClientID { get; set; }
		public Address Address { get; set; }
		public int AddressID { get; set; }
		public List<Product> Products { get; set; } = new();

		public Order(int orderID, DateTime orderDate, string paymetMethod, decimal total, DateTime deliveryForecast, User user, int userID, Client client, int clientID, Address address, int addressID)
		{
			OrderID = orderID;
			OrderDate = orderDate;
			PaymetMethod = paymetMethod;
			Total = total;
			DeliveryForecast = deliveryForecast;
			User = user;
			UserID = userID;
			Client = client;
			ClientID = clientID;
			Address = address;
			AddressID = addressID;
		}

		public Order()
		{
		}
	}
}