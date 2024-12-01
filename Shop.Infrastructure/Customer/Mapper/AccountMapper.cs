using Shop.Application.Interfaces;
using Shop.Application.Security.Services;
using Shop.Entities.Customer;
using Shop.Infrastructure.Customer.Dtos;

namespace Shop.Infrastructure.Customer.Mapper;

public class AccountMapper : IMapper<AddAccountRequestDto, Account>
{
    private readonly IEncryptionService _encryptionService;

    public AccountMapper(IEncryptionService encryptionService)
    {
        _encryptionService = encryptionService;
    }

    public Account ToEntity(AddAccountRequestDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        var account = new Account
        {
            Guid = dto.Id,
            Name = dto.Name != null ? _encryptionService.Encrypt(dto.Name) : null,
            LastName = dto.LastName != null ? _encryptionService.Encrypt(dto.LastName) : null,
            Email = dto.Email != null ? _encryptionService.Encrypt(dto.Email) : null,
            PhoneNumber = dto.PhoneNumber != null ? _encryptionService.Encrypt(dto.PhoneNumber) : null,
            IsActive = dto.IsActive,
            CreateDate = DateTime.Now,
        };

        if (dto.Addresses.Any())
        {
            account.AddAdresses(dto.Addresses.Select(dto => new Address()
            {
                AccountGuid = account.Guid,
                Street = dto.Street,
                City = dto.City,
                Country = dto.Country,
                HouseNumber = dto.HouseNumber,
                IsActive = dto.IsActive,
                IsDefault = dto.IsDefault,
                RawValue = dto.RawValue,
                State = dto.State,
                ZipCode = dto.ZipCode
            }));
        }
        return account;
    }


}
