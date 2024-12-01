using FluentValidation;
using Shop.Infrastructure.Customer.Dtos;

namespace Shop.Infrastructure.Customer.Validators;

public class AddressModelValidator : AbstractValidator<AddressModel>
{
    public AddressModelValidator()
    {
        RuleFor(x => x.RawValue).NotEmpty().NotNull().WithMessage("Address is required");
    }
}
