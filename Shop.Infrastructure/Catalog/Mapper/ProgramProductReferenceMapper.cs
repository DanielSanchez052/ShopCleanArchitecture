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
         Name = dto.Name,
         Description = dto.Description,
         AditionalData = dto.AditionalData,
         Inventory = dto.Inventory,
         Available = dto.Available,
         IsActive = dto.IsActive,
     };
}
