using System.Net;
using src.Extensions;
using src.Models.DTO.ClientDTOS;
using src.Repositories.Interfaces;
using src.Services.Interfaces;

namespace src.Services
{
	public class ClientService : IClientService
	{
		private readonly IClientRepository _repository;

		public ClientService(IClientRepository repository)
		{
			_repository = repository;
		}

		public async Task<ClientDetailsDTO> GetClientByCpfAsync(string cpf)
		{
			var client = await _repository.GetClientByCPFAsync(cpf);
			if (client is null)
				ExceptionExtensions.ThrowBaseException("Cliente não encontrado", HttpStatusCode.NotFound);

			return new ClientDetailsDTO(client);
		}
	}
}