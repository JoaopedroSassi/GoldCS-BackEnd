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
		}
	}
}