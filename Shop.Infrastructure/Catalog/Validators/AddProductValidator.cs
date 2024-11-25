using FluentValidation;
using Shop.Infrastructure.Catalog.Dtos;

namespace Shop.Infrastructure.Catalog.Validators;

public class AddProductValidator : AbstractValidator<AddProductRequestDto>
{
    public AddProductValidator()
    {
        RuleFor(x => x.ProductCode).NotEmpty().NotNull().WithMessage("Product Guid cannot be empty or null");
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Product Name cannot be empty or null");
        RuleFor(x => x.ShortDescription).NotEmpty().NotNull().WithMessage("Product Short Description cannot be empty or null");
        
        RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Product category Iva be greater than 0");
        RuleFor(x => x.ProductTypeId).GreaterThan(0).WithMessage("Product type be greater than 0");
    }
}
