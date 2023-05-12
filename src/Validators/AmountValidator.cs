using FluentValidation;
using src.Models.DTO.Amount;

namespace src.Validators
{
	public class AmountValidator : AbstractValidator<AmountInsertDTO>
	{
		public AmountValidator()
		{
			RuleFor(x => x.Quantity)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Quantidade'")
				.GreaterThan(0)
					.WithMessage("Necessário o campo 'Quantidade' ser maior que 0")
			;

			RuleFor(x => x.Price)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Preço'")
				.GreaterThan(0)
					.WithMessage("Necessário o campo 'Preço' ser maior que 0")
			;
		}
	}
}