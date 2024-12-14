using FluentValidation;
using Shop.Infrastructure.ShopCart.Dtos;

namespace Shop.Infrastructure.ShopCart.Validators;

public class CartItemValidator : AbstractValidator<CartItemDto>
{
    public CartItemValidator()
    {
        RuleFor(x => x.ReferenceGuid).NotEmpty().NotNull().WithMessage("Reference Guid is required");
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
    }
}
