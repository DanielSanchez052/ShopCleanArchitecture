using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Infrastructure.Catalog.Dtos;

namespace Shop.Infrastructure.Catalog.Mapper;

public class ProgramProductReferenceMapper : IMapper<AddProductReferenceRequestDto, ProgramProductReference>
{
    public ProgramProductReference ToEntity(AddProductReferenceRequestDto dto)
     => new ProgramProductReference()
     {
         Guid = Guid.NewGuid().ToString(),
         ProgramProductGuid = dto.ProgramProductGuid,
         Inventory = dto.Inventory,
         Available = dto.Available,
         IsActive = dto.IsActive,
     };
}
