using FluentValidation;

namespace GoldCS.Domain.Models.Request
{
    public class CreateUserValidations : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidations()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(x => x.Email).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .EmailAddress().WithMessage("O campo {0} está em formato inválido");
            RuleFor(x => x.Password).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Must(x => x.Length > 6 && x.Length < 100).WithMessage("O campo {PropertyName} precisa ter entre 6 e 100 caracteres")
                .Equal(x => x.ConfirmPassword).WithMessage("As senhas não conferem");
        }
    }
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Email{ get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
