using FluentValidation;
using Shop.Infrastructure.Catalog.Dtos;
using Shop.Infrastructure.Ordering.Dtos;

namespace Shop.Infrastructure.Ordering.Validators;

public class AddOrderValidator : AbstractValidator<OrderDto>
{
    public AddOrderValidator()
    {
        RuleFor(x => x.AddressId)
            .NotEmpty().WithMessage("Address is required")
            .GreaterThan(0).WithMessage("Address is required");
        RuleFor(x => x.AccountGuid)
            .NotNull().WithMessage("Account is required")
            .NotEmpty().WithMessage("Account is required");
        RuleFor(x => x.PaymentId)
           .NotEmpty().WithMessage("Payment is required")
           .GreaterThan(0).WithMessage("Payment is required");
        RuleFor(x => x.CartId)
            .NotNull().WithMessage("Cart is required")
            .NotEmpty().WithMessage("Cart is required");
    }
}
