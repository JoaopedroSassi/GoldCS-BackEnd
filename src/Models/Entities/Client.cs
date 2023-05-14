using src.Models.Entities;

namespace src.Entities.Models
{
	public class Client
	{
		public int ClientID { get; set; }
		public string Cpf { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string CellPhone { get; set; }
		public string LandlinePhone { get; set; }
		public List<Order> Orders { get; set; } = new ();

		public Client(int clientID, string cpf, string name, string email, string cellPhone, string landlinePhone)
		{
			ClientID = clientID;
			Cpf = cpf;
			Name = name;
			Email = email;
			CellPhone = cellPhone;
			LandlinePhone = landlinePhone;
		}

		public Client(string cpf, string name, string email, string cellPhone, string landlinePhone)
		{
			Cpf = cpf;
			Name = name;
			Email = email;
			CellPhone = cellPhone;
			LandlinePhone = landlinePhone;
		}

		public Client()
		{
		}
	}
}