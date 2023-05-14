using src.Entities.Models;
using src.Models.DTO.OrderDTOS;

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
		public List<OrderProduct> OrderProducts { get; set; } = new();

		public Order(int orderID, string paymetMethod, decimal total, DateTime deliveryForecast, User user, int userID, Client client, int clientID, Address address, int addressID)
		{
			OrderID = orderID;
			OrderDate = DateTime.Now;
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
			OrderDate = DateTime.Now;
		}

		public Order(OrderInsertDTO model)
		{
			OrderDate = DateTime.Now;
			PaymetMethod = model.PaymentMethod;
			Total = model.Total;
			DeliveryForecast = model.DeliveryForecast;
			UserID = model.UserID;
			Client = new Client(model.Client.Cpf, model.Client.Name, model.Client.Email, model.Client.CellPhone, model.Client.LandlinePhone);
			Address = new Address(model.Address.Cep, model.Address.AddressName, model.Address.City, model.Address.District, model.Address.UF, model.Address.Number, model.Address.Complement);
			for (int i = 0; i < model.OrderProducts.Count; i++)
				OrderProducts.Add(new OrderProduct(model.OrderProducts[i]));
		}
	}
}