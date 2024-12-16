using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Payment;

namespace Shop.Infrastructure.Payment.Configuration;

public class PaymentTypeEntityConfiguration : IEntityTypeConfiguration<PaymentType>
{
    public void Configure(EntityTypeBuilder<PaymentType> builder)
    {
        builder.ToTable(nameof(PaymentType), Schemas.Payment);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .IsRequired()
           .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasMaxLength(255);

        builder.Property(x => x.Provider)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Config)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(x => x.IsActive)
            .IsRequired();
    }
}
