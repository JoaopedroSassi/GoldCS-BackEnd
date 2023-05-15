using FluentValidation;
using src.Models.DTO.AmountDTOS;

namespace src.Validators
{
	public class AmountValidator : AbstractValidator<AmountInsertDTO>
	{
		public AmountValidator()
		{
			
		}
	}
}