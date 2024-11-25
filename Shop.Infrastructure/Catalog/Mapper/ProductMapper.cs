using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Infrastructure.Catalog.Dtos;

namespace Shop.Infrastructure.Catalog.Mapper;

public class ProductMapper : IMapper<AddProductRequestDto, Product>
{
    public Product ToEntity(AddProductRequestDto dto)
        => new Product()
        {
            Guid = Guid.NewGuid().ToString(),
            ProductCode = dto.ProductCode,
            Name = dto.Name,
            ProductTypeId = dto.ProductTypeId,
            ShortDescription = dto.ShortDescription,
            LongDescription = dto.LongDescription,
            Terms = dto.Terms,
            Conditions = dto.Conditions,
            Instructions = dto.Instructions,
            NominalValue = dto.NominalValue,
            ImageUrl = dto.ImageUrl,
            CategoryId = dto.CategoryId,
            IsActive = dto.IsActive,
        };
}
