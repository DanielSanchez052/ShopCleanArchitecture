using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Payment;

namespace Shop.Infrastructure.Payment.Configuration;

public class PaymentRulesEntityConfiguration : IEntityTypeConfiguration<PaymentRules>
{
    public void Configure(EntityTypeBuilder<PaymentRules> builder)
    {
        builder.ToTable(nameof(PaymentRules), Schemas.Payment);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Factor)
            .IsRequired()
            .HasPrecision(10, 5);

        builder.Property(p => p.AutoCalulated)
            .IsRequired();

        builder.Property(p => p.IsActive)
           .IsRequired();

        builder.Property(x => x.ProgramId)
            .IsRequired();

        builder.HasOne(x => x.Program)
            .WithMany(x => x.PaymentRules)
            .HasForeignKey(x => x.ProgramId);
    }
}
