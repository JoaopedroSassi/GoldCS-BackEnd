using FluentValidation;
using src.Entities.DTO.Client;

namespace src.Validators
{
	public class ClientValidator : AbstractValidator<ClientInsertDTO>
    {
        public ClientValidator()
		{
			RuleFor(x => x.Cpf)
				.NotEmpty().WithMessage("Necessário preencher o campo CPF")
				.Matches(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$").WithMessage("CPF no formato inválido - xxx.xxx.xxx-xx")
				;
			
			
		}
    }
}