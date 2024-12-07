using Shop.Application.Interfaces;
using Shop.Application.Security.Services;
using Shop.Entities.Customer;
using Shop.Infrastructure.Customer.ViewModel;

namespace Shop.Infrastructure.Customer.Presenter;

public class AccountPresenter : IPresenter<Account, AccountViewModel>
{
    private readonly IEncryptionService _encryptionService;
    public AccountPresenter(IEncryptionService encryptionService)
    {
        _encryptionService = encryptionService;
    }

    public AccountViewModel? Present(Account? entity)
    {
        if(entity == null)
        {
            return null;
        }

        return new AccountViewModel()
        {
            Guid = entity.Guid,
            Name = string.IsNullOrEmpty(entity.Name) ? string.Empty : _encryptionService.Decrypt(entity.Name),
            LastName = string.IsNullOrEmpty(entity.LastName) ? string.Empty : _encryptionService.Decrypt(entity.LastName),
            PhoneNumber = string.IsNullOrEmpty(entity.PhoneNumber) ? string.Empty : _encryptionService.Decrypt(entity.PhoneNumber),
            Email = string.IsNullOrEmpty(entity.Email) ? string.Empty : _encryptionService.Decrypt(entity.Email),
            IsActive = entity.IsActive,
            Addresses = entity.Addresses.Select(x => new AddressViewModel()
            {
                Id = x.Id,
                RawValue = x.RawValue,
                Street = x.Street,
                City = x.City,
                State = x.State,
                Country = x.Country,
                ZipCode = x.ZipCode,
                HouseNumber = x.HouseNumber,
                IsActive = x.IsActive,
                IsDefault = x.IsDefault,
            })
        };
    }

    public IEnumerable<AccountViewModel?> PresentCollection(IEnumerable<Account> entities)
        => entities == null ? Enumerable.Empty<AccountViewModel>() : entities.Select(Present);
}
