using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Catalog;

namespace Shop.Infrastructure.Catalog.Configuration;

internal class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product), Schemas.Catalog);

        builder.HasKey(x => x.Guid);

        builder.Property(a => a.Guid)
            .IsRequired()
            .HasMaxLength(36);

        builder.Property(a => a.ProductTypeId)
            .IsRequired();

        builder.HasOne(x => x.ProductType)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.ProductTypeId);

        builder.Property(a => a.ProductCode)
            .IsRequired()
            .HasMaxLength(55);

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(a => a.ShortDescription)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(a => a.LongDescription)
           .HasMaxLength(500);

        builder.Property(a => a.Terms)
          .HasMaxLength(500);

        builder.Property(a => a.Conditions)
          .HasMaxLength(500);

        builder.Property(a => a.Instructions)
          .HasMaxLength(500);

        builder.Property(a => a.NominalValue)
            .HasMaxLength(55);

        builder.Property(a => a.CreateDate)
           .IsRequired();

        builder.Property(a => a.CategoryId)
            .IsRequired();

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId);

        builder.Property(a => a.IsActive)
            .IsRequired();

    }
}
