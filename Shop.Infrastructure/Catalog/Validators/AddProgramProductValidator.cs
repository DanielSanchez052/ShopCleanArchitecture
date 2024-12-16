using FluentValidation;
using Shop.Infrastructure.Catalog.Dtos;

namespace Shop.Infrastructure.Catalog.Validators;

public class AddProgramProductValidator : AbstractValidator<AddProgramProductRequestDto>
{
    public AddProgramProductValidator()
    {
        RuleFor(x => x.ProductGuid).NotEmpty().NotNull().WithMessage("Product Guid cannot be empty or null");
        RuleFor(x => x.ProgramId).GreaterThan(0).WithMessage("Program Id must be greater than 0");
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Product Name cannot be empty or null");
        RuleFor(x => x.ShortDescription).NotEmpty().NotNull().WithMessage("Product Short Description cannot be empty or null");
        RuleFor(x => x.BaseCost).GreaterThan(0).WithMessage("Product Base Cost must be greater than 0");
        RuleFor(x => x.BasePrice).GreaterThan(0).WithMessage("Product Base Price must be greater than 0");
        RuleFor(x => x.Iva).GreaterThan(0).WithMessage("Product Base Iva be greater than 0");
        RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Product category Iva be greater than 0");
        RuleFor(x => x.ProductReferences).NotNull().ForEach(x => x.SetValidator(new AddProgramReferenceValidator()));
    }
}
