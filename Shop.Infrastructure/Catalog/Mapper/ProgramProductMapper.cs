using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Infrastructure.Catalog.Dtos;

namespace Shop.Infrastructure.Catalog.Mapper;

public class ProgramProductMapper : IMapper<AddProgramProductRequestDto, ProgramProduct>
{
    public ProgramProduct ToEntity(AddProgramProductRequestDto dto)
        => new ProgramProduct()
        {
            Guid = Guid.NewGuid().ToString(),
            ProgramId = dto.ProgramId,
            ProductGuid = dto.ProductGuid,
            Name = dto.Name,
            ShortDescription = dto.ShortDescription,
            LongDescription = dto.LongDescription,
            Terms = dto.Terms,
            Conditions = dto.Conditions,
            Instructions = dto.Instructions,
            NominalValue = dto.NominalValue,
            Segment = dto.Segment,
            BasePrice = dto.BasePrice,
            CategoryId = dto.CategoryId,
            Iva = dto.Iva,
            BaseCost = dto.BaseCost,
            IsActive = dto.IsActive
        };
}
