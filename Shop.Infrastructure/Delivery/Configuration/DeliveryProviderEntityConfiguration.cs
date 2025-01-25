using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Delivery;

namespace Shop.Infrastructure.Delivery.Configuration;

public class DeliveryProviderEntityConfiguration : IEntityTypeConfiguration<DeliveryProvider>
{
    public void Configure(EntityTypeBuilder<DeliveryProvider> builder)
    {
        builder.ToTable(nameof(DeliveryProvider), Schemas.Delivery);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(155)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.OwnsOne(x => x.Config, builder => builder.ToJson());

        builder.Property(x => x.IsActive)
            .IsRequired();
    }
}
