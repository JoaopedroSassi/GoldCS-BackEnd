using FluentValidation;
using src.Models.DTO.ProductDTOS;

namespace src.Validators
{
	public class ProductValidator : AbstractValidator<ProductInsertDTO>
	{
		public ProductValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Nome'")
			;

			RuleFor(x => x.Version)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Version'")
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