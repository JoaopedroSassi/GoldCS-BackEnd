using System.Data;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using src.Entities.DTO.Client;
using src.Entities.Models;
using src.Exceptions;
using src.Models.DTO.Client;
using src.Repositories.Interfaces;
using src.Services.Interfaces;

namespace src.Services
{
	public class ClientService : IClientService
	{
		private readonly IClientRepository _repository;
		private readonly IMapper _mapper;

		public ClientService(IClientRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ClientDetailsDTO>> GetAllClientsAsync()
		{
			return _mapper.Map<IEnumerable<ClientDetailsDTO>>(await _repository.GetClientsAsync());
		}

		public async Task<ClientDetailsDTO> GetClientByIdAsync(int id)
		{
			var client = _mapper.Map<ClientDetailsDTO>(await _repository.GetClientByIdAsync(id));
			if (client is null)
				throw new BaseException("Cliente não encontrado", HttpStatusCode.NotFound, typeof(NotFoundObjectResult).FullName);

			return client;
		}

		public async Task<bool> InsertClientAsync(ClientInsertDTO model)
		{
			Client client = _mapper.Map<Client>(model);

			_repository.Insert(client);	
			if (!(await _repository.SaveChangesAsync()))
				throw new BaseException("Erro ao salvar no banco de dados!", HttpStatusCode.BadRequest, typeof(DBConcurrencyException).FullName);

			return true;
		}
	}
}