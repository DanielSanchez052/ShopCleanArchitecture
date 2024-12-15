using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Ordering;

namespace Shop.Infrastructure.Ordering.Configuration;

public class OrderChangeHistoryEntityConfiguration : IEntityTypeConfiguration<OrderChangeHistory>
{
    public void Configure(EntityTypeBuilder<OrderChangeHistory> builder)
    {
        builder.ToTable(nameof(OrderChangeHistory), Schemas.Ordering);

        builder.HasKey(x => x.Guid);

        builder.Property(x => x.Guid)
            .IsRequired()
            .HasMaxLength(36);

        builder.Property(x => x.OrderGuid)
            .IsRequired(false)
            .HasMaxLength(55);

        builder.HasOne(x => x.Order)
            .WithMany(x => x.ChangeHistory)
            .HasForeignKey(x => x.OrderGuid)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.OrderDetailGuid)
            .IsRequired(false)
            .HasMaxLength(36);

        builder.HasOne(x => x.OrderDetail)
            .WithMany(x => x.ChangeHistory)
            .HasForeignKey(x => x.OrderDetailGuid)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.StatusId)
            .IsRequired();

        builder.Property(x => x.PaymentTypeId)
            .IsRequired(false);

        builder.Property(x => x.Source)
           .IsRequired()
           .HasMaxLength(255);

        builder.Property(x => x.CreateDate)
          .IsRequired();
    }
}
