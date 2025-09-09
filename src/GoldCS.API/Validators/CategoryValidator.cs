using FluentValidation;
using src.Models.DTO.CategoryDTOS;

namespace src.Validators
{
	public class CategoryValidator : AbstractValidator<CategoryInsertDTO>
	{
		public CategoryValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Nome'")
			;
		}
	}
}