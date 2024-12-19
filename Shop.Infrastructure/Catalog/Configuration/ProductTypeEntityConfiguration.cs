using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Catalog;

namespace Shop.Infrastructure.Catalog.Configuration;

public class ProductTypeEntityConfiguration : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.ToTable(nameof(ProductType), Schemas.Catalog);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .IsRequired()
           .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.OwnsOne(x => x.Config, builder =>
        {
            builder.ToJson();
        });

        builder.Property(x => x.IsActive)
            .IsRequired();
    }
}
