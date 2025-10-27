using FluentValidation;

namespace GoldCS.Domain.Models.Request
{
    public class ProductRequests
    {
        public class Insert
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal CostPrice { get; set; }
            public decimal Height { get; set; }
            public decimal Width { get; set; }
            public string MeasureType { get; set; }
            public int Stock { get; set; }
            public int CategoryId { get; set; }
        }

        public class Update
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal CostPrice { get; set; }
            public decimal Height { get; set; }
            public decimal Width { get; set; }
            public string MeasureType { get; set; }
        }
        public class InsertAmount
        {
            public int ProductId { get; set; }
            public int AmountToInsert { get; set; }
        }

        public class Inactivate
        {
            public int ProductId { get; set; }
        }
    }
    public class InsertProductValidations : AbstractValidator<ProductRequests.Insert>
    {
        public InsertProductValidations()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(x => x.CostPrice)
                .GreaterThan(0).WithMessage("O campo {PropertyName} deve ser maior que zero");

            RuleFor(x => x.Height)
                .GreaterThan(0).WithMessage("O campo {PropertyName} deve ser maior que zero");

            RuleFor(x => x.Width)
                .GreaterThan(0).WithMessage("O campo {PropertyName} deve ser maior que zero");

            RuleFor(x => x.MeasureType)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} não pode ser negativo");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
    public class UpdateProductValidations : AbstractValidator<ProductRequests.Update>
    {
        public UpdateProductValidations()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
    public class InsertAmountValidations : AbstractValidator<ProductRequests.InsertAmount>
    {
        public InsertAmountValidations()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(x => x.AmountToInsert)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ter valor maior que zero");
        }
    }
    public class DeleteProductValidations : AbstractValidator<ProductRequests.Inactivate>
    {
        public DeleteProductValidations()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
