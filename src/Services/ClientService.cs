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

		public async Task InsertClientAsync(ClientInsertDTO model)
		{
			_repository.Insert(_mapper.Map<Client>(model));	
			if (!(await _repository.SaveChangesAsync()))
				throw new BaseException("Erro ao adicionar o cliente no banco de dados", HttpStatusCode.BadRequest, typeof(DBConcurrencyException).FullName);
		}

		public async Task DeleteClientAsync(int id)
		{
			var client = await _repository.GetClientByIdAsync(id);
			if (client is null)
				throw new BaseException("Cliente não encontrado", HttpStatusCode.NotFound, typeof(NotFoundObjectResult).FullName);

			_repository.Delete(client);
			if (!(await _repository.SaveChangesAsync()))
				throw new BaseException("Erro ao deletar o cliente no banco de dados", HttpStatusCode.BadRequest, typeof(DBConcurrencyException).FullName);
		}
	}
}