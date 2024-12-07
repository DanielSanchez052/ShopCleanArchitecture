using Shop.Application.Interfaces;
using Shop.Entities.Customer;
using Shop.Infrastructure.Customer.Dtos;

namespace Shop.Infrastructure.Customer.Mapper;

public class AddressMapper : IMapper<AddressModel, Address>
{
    public Address ToEntity(AddressModel dto)
    {
        return new Address()
        {
            City = dto.City,
            State = dto.State,
            Street = dto.Street,
            ZipCode = dto.ZipCode,
            Country = dto.Country,
            IsActive = dto.IsActive,
            RawValue = dto.RawValue,
            IsDefault = dto.IsDefault,
            HouseNumber = dto.HouseNumber,
        };
    }
}
