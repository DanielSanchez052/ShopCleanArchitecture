using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Digital;

namespace Shop.Infrastructure.Digital.Configuration;

public class ExpirationTypeEntityConfiguration : IEntityTypeConfiguration<ExpirationType>
{
    public void Configure(EntityTypeBuilder<ExpirationType> builder)
    {
        builder.ToTable(nameof(ExpirationType), Schemas.Digital);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .IsRequired();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Config)
            .HasMaxLength(255);

        builder.Property(x => x.IsActive)
            .IsRequired();
    }
}
