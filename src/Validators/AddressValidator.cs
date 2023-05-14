using FluentValidation;
using src.Extensions;
using src.Models.DTO.AddressDTOS;

namespace src.Validators
{
	public class AddressValidator : AbstractValidator<AddressInsertDTO>
	{
		public AddressValidator()
		{
			RuleFor(x => x.Cep)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'CEP'")
				.Must(x => x.IsCepValid())
					.WithMessage("CEP no formato inválido - xxxxx-xxx")
			;

			RuleFor(x => x.AddressName)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Address Name'")
			;

			RuleFor(x => x.City)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'City'")
			;

			RuleFor(x => x.District)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'District'")
			;

			RuleFor(x => x.UF)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'UF'")
				.Must(y => y.IsUFValid())
					.WithMessage("UF no formato inválido - XX")
			;

			RuleFor(x => x.Number)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Number'")
			;
		}
	}
}