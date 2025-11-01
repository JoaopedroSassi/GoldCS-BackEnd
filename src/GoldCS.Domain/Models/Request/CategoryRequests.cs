
using FluentValidation;

namespace GoldCS.Domain.Models.Request
{
    public class CategoryRequests
    {
        public class Create
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }
        public class Alter
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
        public class Deactivate
        {
            public int CategoryId { get; set; }
        }
        
    }
    public class InsertCategoryValidations : AbstractValidator<CategoryRequests.Create>
    {
        public InsertCategoryValidations()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(x => x.Description).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
    public class UpdateCategoryValidations : AbstractValidator<CategoryRequests.Alter>
    {
        public UpdateCategoryValidations()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(x => x.Name).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(x => x.Description).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
    public class DeleteCategoryValidations : AbstractValidator<CategoryRequests.Deactivate>
    {
        public DeleteCategoryValidations()
        {
            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
