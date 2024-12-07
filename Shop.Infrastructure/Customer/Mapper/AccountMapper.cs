using Shop.Application.Interfaces;
using Shop.Application.Security.Services;
using Shop.Entities.Customer;
using Shop.Infrastructure.Customer.Dtos;

namespace Shop.Infrastructure.Customer.Mapper;

public class AccountMapper : IMapper<AddAccountRequestDto, Account>
{
    private readonly IEncryptionService _encryptionService;
    private readonly IMapper<AddressModel, Address> _addressMapper;

    public AccountMapper(IEncryptionService encryptionService, IMapper<AddressModel, Address> addressMapper)
    {
        _encryptionService = encryptionService;
        _addressMapper = addressMapper;
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
            account.AddAdresses(dto.Addresses.Select(_addressMapper.ToEntity).ToList());
        }
        return account;
    }


}
