using FluentValidation;
using src.Entities.DTO.Client;

namespace src.Validators
{
	public class ClientValidator : AbstractValidator<ClientInsertDTO>
    {
        public ClientValidator()
		{
			RuleFor(x => x.Cpf)
				.NotEmpty().WithMessage("Necessário preencher o campo 'CPF'")
				.Matches(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$").WithMessage("CPF no formato inválido - xxx.xxx.xxx-xx")
			;
			
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Necessário preencher o campo 'Nome'")
				.Length(1, 150).WithMessage("Campo maior do que o permitido")
			;

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Necessário preencher o campo 'Email'")
				.EmailAddress().WithMessage("Email no foramto inválido")
			;

			RuleFor(x => x.CellPhone)
				.NotEmpty().WithMessage("Necessário preencher o campo 'Cell Phone'")
			;
		}
    }
}