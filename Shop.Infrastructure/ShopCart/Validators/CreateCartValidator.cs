using FluentValidation;
using Shop.Infrastructure.ShopCart.Dtos;

namespace Shop.Infrastructure.ShopCart.Validators;

public class CreateCartValidator : AbstractValidator<CartDto>
{
    public CreateCartValidator()
    {
        RuleFor(x => x.AccountGuid).NotEmpty().NotNull().WithMessage("Account Guid is required");
    }
}
