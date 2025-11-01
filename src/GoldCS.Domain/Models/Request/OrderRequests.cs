using FluentValidation;
using GoldCS.Domain.Util;
using static GoldCS.Domain.Models.Request.OrderRequests;

namespace GoldCS.Domain.Models.Request
{
    public class OrderRequests
    {
        public class CreateOrder
        {
            public string UserName { get; set; }
            public string PaymentMethod { get; set; }
            public DateTime DeliveryDate { get; set; }
            public string Cpf {  get; set; }
            public string ClientName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Cellphone { get; set; }
            public string Cep { get; set; }
            public string Logradouro { get; set; }
            public string Bairro { get; set; }
            public string Numero { get; set; }
            public string Complemento { get; set; }
            public string Cidade { get; set; }
            public string UF { get; set; }
            public AdressType AdressType { get; set; }
            public List<OrderProducts> Products { get; set; }

        }

        public class OrderProducts
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public decimal UnitaryPrice { get; set; }
        }
    }
    public class CreateOrderValidations : AbstractValidator<CreateOrder>
    {
        public CreateOrderValidations()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .MaximumLength(100).WithMessage("O campo {PropertyName} deve conter no máximo {MaxLength} caracteres");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(x => x.DeliveryDate)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Must(date => date.Date >= DateTime.Today)
                .WithMessage("A data de entrega deve ser igual ou posterior à data atual");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Matches(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$")
                .WithMessage("O campo {PropertyName} deve estar no formato válido.");

            RuleFor(x => x.ClientName)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .MaximumLength(120).WithMessage("O campo {PropertyName} deve conter no máximo {MaxLength} caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .EmailAddress().WithMessage("O campo {PropertyName} deve conter um e-mail válido");

            RuleFor(x => x.Cellphone)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$")
                .WithMessage("O campo {PropertyName} deve conter um celular válido.");

            RuleFor(x => x.Phone)
                .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$")
                .When(x => !string.IsNullOrWhiteSpace(x.Phone))
                .WithMessage("O campo {PropertyName} deve conter um telefone válido.");

            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Matches(@"^\d{5}-?\d{3}$").WithMessage("O campo {PropertyName} deve estar no formato válido.");

            RuleFor(x => x.Logradouro)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(x => x.Bairro)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(x => x.AdressType)
                .IsInEnum().WithMessage("O campo {PropertyName} deve conter um tipo de endereço válido");

            RuleFor(x => x.Products)
                .NotEmpty().WithMessage("O pedido deve conter ao menos um produto")
                .Must(list => list != null && list.Count > 0)
                .WithMessage("O pedido deve conter ao menos um produto");
        }
    }
}
