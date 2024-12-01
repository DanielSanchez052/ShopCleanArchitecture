using FluentValidation;
using Shop.Infrastructure.Customer.Dtos;

namespace Shop.Infrastructure.Customer.Validators;

public class AddAccountValidator : AbstractValidator<AddAccountRequestDto>
{
    public AddAccountValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().NotNull().WithMessage("Account Id is required")
            .MaximumLength(36).WithMessage("maximum length of id is 36");
        RuleFor(x => x.Name)
            .NotEmpty().NotNull().WithMessage("Account name is required")
            .MaximumLength(155).WithMessage("maximum length of name is 155");
        RuleFor(x => x.LastName)
           .NotEmpty().NotNull().WithMessage("Account last name is required")
           .MaximumLength(155).WithMessage("maximum length of last name is 155");
        RuleFor(x => x.Email)
           .NotEmpty().NotNull().WithMessage("Account email is required")
           .MaximumLength(255).WithMessage("maximum length of email is 255");
        RuleFor(x => x.PhoneNumber)
           .NotEmpty().NotNull().WithMessage("Account phone number is required")
           .MaximumLength(255).WithMessage("maximum length of phone number is 20");
        RuleFor(x => x.Addresses).ForEach(a => a.SetValidator(new AddressModelValidator()));
    }
}
