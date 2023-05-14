using FluentValidation;
using src.Entities.DTO.ClientDTOS;
using src.Extensions;

namespace src.Validators
{
	public class ClientValidator : AbstractValidator<ClientInsertDTO>
    {
        public ClientValidator()
		{
			RuleFor(x => x.Cpf)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'CPF'")
				.Must(x => x.IsCpfValid())
					.WithMessage("CPF no formato inválido - xxx.xxx.xxx-xx")
			;
			
			RuleFor(x => x.Name)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Nome'")
				.Length(1, 150)
					.WithMessage("Campo maior do que o permitido")
			;

			RuleFor(x => x.Email)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Email'")
				.Must(x => x.IsEmailValid())
					.WithMessage("Email no foramto inválido")
			;

			RuleFor(x => x.CellPhone)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Cell Phone'")
			;
		}
    }
}