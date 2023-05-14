using src.Entities.Models;

namespace src.Models.DTO.ClientDTOS
{
	public class ClientDetailsDTO
    {
        public int ClientID { get; set; }
		public string Cpf { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string CellPhone { get; set; }
		public string LandlinePhone { get; set; }

		public ClientDetailsDTO()
		{
		}

		public ClientDetailsDTO(int clientID, string cpf, string name, string email, string cellPhone, string landlinePhone)
		{
			ClientID = clientID;
			Cpf = cpf;
			Name = name;
			Email = email;
			CellPhone = cellPhone;
			LandlinePhone = landlinePhone;
		}

		public ClientDetailsDTO(Client model)
		{
			ClientID = model.ClientID;
			Cpf = model.Cpf;
			Name = model.Name;
			Email = model.Email;
			CellPhone = model.CellPhone;
			LandlinePhone = model.LandlinePhone;
		}
    }
}