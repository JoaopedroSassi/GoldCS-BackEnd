using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Models.DTO.Client
{
    public class ClientDetailsDTO
    {
        public int ClientID { get; set; }
		public string Cpf { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string CellPhone { get; set; }
		public string LandlinePhone { get; set; }

		public ClientDetailsDTO(int clientID, string cpf, string name, string email, string cellPhone, string landlinePhone)
		{
			ClientID = clientID;
			Cpf = cpf;
			Name = name;
			Email = email;
			CellPhone = cellPhone;
			LandlinePhone = landlinePhone;
		}
    }
}