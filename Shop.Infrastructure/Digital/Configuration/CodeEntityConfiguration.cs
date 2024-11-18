using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Digital;

namespace Shop.Infrastructure.Digital.Configuration;

public class CodeEntityConfiguration : IEntityTypeConfiguration<Code>
{
    public void Configure(EntityTypeBuilder<Code> builder)
    {
        builder.ToTable(nameof(Code), Schemas.Digital);

        builder.HasKey(x => x.Guid);

        builder.Property(x => x.Guid)
            .IsRequired()
            .HasMaxLength(36);

        builder.Property(x => x.ProductReferenceGuid)
            .IsRequired()
            .HasMaxLength(36);

        builder.HasOne(x => x.ProgramProductReference)
            .WithMany(x => x.Codes)
            .HasForeignKey(x => x.ProductReferenceGuid)
            .OnDelete(DeleteBehavior.NoAction);


        builder.Property(x => x.Link)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Used)
            .IsRequired();

        builder.Property(x => x.UsedDate)
            .IsRequired();

        builder.Property(x => x.CreateDate)
            .IsRequired();

        builder.Property(x => x.ExpirationTypeId)
            .IsRequired();

        builder.HasOne(x => x.ExpirationType)
            .WithMany(x => x.Codes)
            .HasForeignKey(x => x.ExpirationTypeId);

        builder.Property(x => x.Expiration)
            .IsRequired()
            .HasMaxLength(55);

        builder.Property(x => x.IsActive)
            .IsRequired();
    }
}
