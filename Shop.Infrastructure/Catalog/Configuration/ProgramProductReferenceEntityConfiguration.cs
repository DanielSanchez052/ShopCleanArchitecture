using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Catalog;

namespace Shop.Infrastructure.Catalog.Configuration;

public class ProgramProductReferenceEntityConfiguration : IEntityTypeConfiguration<ProgramProductReference>
{
    public void Configure(EntityTypeBuilder<ProgramProductReference> builder)
    {
        builder.ToTable(nameof(ProgramProductReference), Schemas.Catalog);

        builder.HasKey(x => x.Guid);

        builder.Property(a => a.Guid)
            .IsRequired()
            .HasMaxLength(36);

        builder.HasOne(x => x.ProgramProduct)
            .WithMany(x => x.ProgramProductReferences)
            .HasForeignKey(x => x.ProgramProductGuid);

        builder.Property(x => x.Inventory)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(x => x.Available)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(x => x.IsActive)
            .IsRequired();
    }
}
