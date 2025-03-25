using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Ordering;

namespace Shop.Infrastructure.Ordering.Configuration;

public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(nameof(Order), Schemas.Ordering);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasMaxLength(55);

        builder.Property(x => x.AddressId)
            .IsRequired()
            .HasMaxLength(36);

        builder.HasOne(x => x.Address)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.AddressId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.CreateDate)
            .IsRequired();

        builder.Property(x => x.AccountGuid)
            .IsRequired()
            .HasMaxLength(36);

        builder.HasOne(x => x.Account)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.AccountGuid)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.PaymentTypeId)
            .IsRequired();

        builder.HasOne(x => x.PaymentType)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.PaymentTypeId);

        builder.Property(x => x.StatusId)
            .IsRequired();

        builder.HasOne(x => x.Status)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.StatusId);

        builder.Property(x => x.ProgramId)
            .IsRequired();

        builder.HasOne(x => x.Program)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.ProgramId);
    }
}
