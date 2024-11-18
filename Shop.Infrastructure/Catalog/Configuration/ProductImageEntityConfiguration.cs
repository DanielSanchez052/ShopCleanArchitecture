using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Catalog;

namespace Shop.Infrastructure.Catalog.Configuration;

public class ProductImageEntityConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.ToTable(nameof(ProductImage), Schemas.Catalog);

        builder.HasKey(x => x.Guid);

        builder.Property(x => x.Guid)
            .IsRequired()
            .HasMaxLength(36);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.ImageUrl)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.BaseUrl)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.IsSmall)
            .IsRequired();

        builder.Property(x => x.ProductGuid)
            .IsRequired()
            .HasMaxLength(36);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductImages)
            .HasForeignKey(x => x.ProductGuid);

        builder.Property(x => x.IsActive)
            .IsRequired();
    }
}
