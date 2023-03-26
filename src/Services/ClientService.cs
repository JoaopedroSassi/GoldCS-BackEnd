using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entities.DTO.Client;
using src.Entities.Models;
using src.Services.Interfaces;

namespace src.Services
{
	public class ClientService : IClientService
	{
		public ClientInsertDTO InsertClient(Client model)
		{
			return new ClientInsertDTO(model.Cpf, model.Name, model.Email, model.CellPhone, model.LandlinePhone);
		}
	}
}