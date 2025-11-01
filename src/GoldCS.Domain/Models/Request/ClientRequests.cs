using FluentValidation;
using static GoldCS.Domain.Models.Request.ClientRequests;

namespace GoldCS.Domain.Models.Request
{
    public class ClientRequests
    {
        public class RegisterClient
        {
            public string Name { get; set; }
            public string Cpf { get; set; }
            public string Email { get; set; }
            public string CellPhone { get; set; }
            public string Phone { get; set; }
        }
        public class UpdateClient
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string CellPhone { get; set; }
            public string Phone { get; set; }
        }
        public class GetByCpf
        {
            public string Cpf { get; set; }
        }
    }

    public class RegisterValidations : AbstractValidator<RegisterClient>
    {
        public RegisterValidations()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .MinimumLength(3).WithMessage("O campo {PropertyName} deve conter no mínimo {MinLength} caracteres")
                .MaximumLength(100).WithMessage("O campo {PropertyName} deve conter no máximo {MaxLength} caracteres");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Matches(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$").WithMessage("O campo {PropertyName} deve estar no formato válido.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .EmailAddress().WithMessage("O campo {PropertyName} deve conter um e-mail válido");

            RuleFor(x => x.CellPhone)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$").WithMessage("O campo {PropertyName} deve conter um celular válido.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$").WithMessage("O campo {PropertyName} deve conter um telefone válido (ex: 11 3456-7890)");
        }
    }
    public class UpdateClientValidations : AbstractValidator<UpdateClient>
    {
        public UpdateClientValidations()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .MinimumLength(3).WithMessage("O campo {PropertyName} deve conter no mínimo {MinLength} caracteres")
                .MaximumLength(100).WithMessage("O campo {PropertyName} deve conter no máximo {MaxLength} caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .EmailAddress().WithMessage("O campo {PropertyName} deve conter um e-mail válido");

            RuleFor(x => x.CellPhone)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$").WithMessage("O campo {PropertyName} deve conter um celular válido.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$").WithMessage("O campo {PropertyName} deve conter um telefone válido (ex: 11 3456-7890)");
        }
    }
    public class GetByCpfValidations : AbstractValidator<GetByCpf>
    {
        public GetByCpfValidations()
        {
            RuleFor(x => x.Cpf)
               .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
               .Matches(@"^\d{3}\.?\d{3}\.?\d{3}-?\d{2}$").WithMessage("O campo {PropertyName} deve estar no formato válido.");
        }
    }
}
