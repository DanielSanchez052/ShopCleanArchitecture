using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Catalog;

namespace Shop.Infrastructure.Catalog.Configuration;

public class ProgramProductEntityConfiguration : IEntityTypeConfiguration<ProgramProduct>
{
    public void Configure(EntityTypeBuilder<ProgramProduct> builder)
    {
        builder.ToTable(nameof(ProgramProduct), Schemas.Catalog);

        builder.HasKey(x => x.Guid);

        builder.Property(a => a.Guid)
            .IsRequired()
            .HasMaxLength(36);

        builder.Property(a => a.ProductGuid)
            .IsRequired()
            .HasMaxLength(36);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProgramProducts)
            .HasForeignKey(x => x.ProductGuid)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(a => a.ProgramId)
         .IsRequired();

        builder.HasOne(x => x.Program)
            .WithMany(x => x.ProgramProducts)
            .HasForeignKey(x => x.ProgramId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.DeliveryProvider)
            .WithMany(x => x.ProgramProducts)
            .HasForeignKey(x => x.DeliveryProviderId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(a => a.DeliveryProviderId)
         .IsRequired();

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

        builder.Property(a => a.Segment)
            .HasMaxLength(255);

        builder.Property(x => x.BasePrice)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Iva)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.BaseCost)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.PointValue)
            .IsRequired(false);

        builder.Property(a => a.CategoryId)
          .IsRequired();

        builder.HasOne(x => x.Category)
            .WithMany(x => x.ProgramProducts)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.CreateDate)
            .IsRequired();

        builder.Property(a => a.IsActive)
            .IsRequired();

        builder.HasQueryFilter(p => p.BasePrice > 0);


    }
}
