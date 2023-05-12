using System.Net;
using AutoMapper;
using src.Extensions;
using src.Models.DTO.Amount;
using src.Models.Entities;
using src.Repositories.Interfaces;
using src.Services.Interfaces;

namespace src.Services
{
	public class AmountService : IAmountService
    {
        private readonly IAmountRepository _repository;
		private readonly IMapper _mapper;

		public AmountService(IAmountRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task InsertAmountAsync(AmountInsertDTO model)
		{
			var obj = _mapper.Map<Amount>(model);
			_repository.Insert(obj);
			
			if (!(await _repository.SaveChangesAsync()))
				ExceptionExtensions.ThrowBaseException("Erro ao adicionar o estoque no banco de dados", HttpStatusCode.BadRequest);
		}
	}
}