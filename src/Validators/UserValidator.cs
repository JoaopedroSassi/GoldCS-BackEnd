using FluentValidation;
using src.Models.DTO.User;
using src.Extensions;

namespace src.Validators
{
	public class UserValidator : AbstractValidator<UserRegisterDTO>
	{
		public UserValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Nome'")
			;

			RuleFor(x => x.Email)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Email'")
				.Must(x => x.IsEmailValid())
					.WithMessage("Email no foramto inválido")
			;

			RuleFor(x => x.Password)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Nome'")
				.Must(x => x.IsPasswordValid())
					.WithMessage("Password no foramto inválido")
			;

			RuleFor(x => x.Role)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Role'")
			;
		}
	}
}