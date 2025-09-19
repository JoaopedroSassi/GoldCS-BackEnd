
using FluentValidation;

namespace GoldCS.Domain.Models.Request
{
    public class CategoryRequests
    {
        public class Insert
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }
        public class Update
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
        
    }
    public class InsertCategoryValidations : AbstractValidator<CategoryRequests.Insert>
    {
        public InsertCategoryValidations()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(x => x.Description).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
    public class UpdateCategoryValidations : AbstractValidator<CategoryRequests.Update>
    {
        public UpdateCategoryValidations()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(x => x.Name).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(x => x.Description).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
