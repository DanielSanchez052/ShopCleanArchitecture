using FluentValidation;
using Shop.Infrastructure.Catalog.Dtos;

namespace Shop.Infrastructure.Catalog.Validators;

public class AddProgramReferenceValidator : AbstractValidator<AddProductReferenceRequestDto>
{
    public AddProgramReferenceValidator()
    {
        RuleFor(x => x.ProgramProductGuid).NotEmpty().NotNull().WithMessage("Program Product Guid cannot be empty or null");
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("reference Name cannot be empty or null");
        RuleFor(x => x.Inventory).GreaterThan(0).WithMessage("reference Inventory must be greater than 0");
    }
}
