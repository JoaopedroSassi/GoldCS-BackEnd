using src.Extensions;
using FluentValidation;
using src.Models.DTO.OrderDTOS;

namespace src.Validators
{
	public class OrderValidator : AbstractValidator<OrderInsertDTO>
	{
		public OrderValidator()
		{
			ClientData();
			AddressData();
			OrderData();
		}

		public void OrderData()
		{
			RuleFor(x => x.PaymentMethod)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Payment Method'")
			;

			RuleFor(x => x.DeliveryForecast)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Delivery Forecast'")
			;
		}

		public void ClientData()
		{
			RuleFor(x => x.Client.Cpf)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'CPF'")
				.Must(x => x.IsCpfValid())
					.WithMessage("CPF no formato inválido - xxx.xxx.xxx-xx")
			;

			RuleFor(x => x.Client.Name)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Nome'")
				.Length(1, 150)
					.WithMessage("Campo maior do que o permitido")
			;

			RuleFor(x => x.Client.Email)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Email'")
				.Must(x => x.IsEmailValid())
					.WithMessage("Email no foramto inválido")
			;

			RuleFor(x => x.Client.CellPhone)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Cell Phone'")
			;
		}

		public void AddressData()
		{
			RuleFor(x => x.Address.Cep)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'CEP'")
				.Must(x => x.IsCepValid())
					.WithMessage("CEP no formato inválido - xxxxx-xxx")
			;

			RuleFor(x => x.Address.AddressName)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Address Name'")
			;

			RuleFor(x => x.Address.City)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'City'")
			;

			RuleFor(x => x.Address.District)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'District'")
			;

			/*RuleFor(x => x.Address.UF)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'UF'")
				.Must(y => y.IsUFValid())
					.WithMessage("UF no formato inválido - XX")
			;*/

			RuleFor(x => x.Address.Number)
				.NotEmpty()
					.WithMessage("Necessário preencher o campo 'Number'")
			;
		}
	}
}