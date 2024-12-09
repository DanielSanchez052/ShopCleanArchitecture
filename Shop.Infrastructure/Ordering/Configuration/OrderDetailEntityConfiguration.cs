using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Ordering;

namespace Shop.Infrastructure.Ordering.Configuration;

public class OrderDetailEntityConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable(nameof(OrderDetail), Schemas.Ordering);

        builder.HasKey(x => x.Guid);

        builder.Property(x => x.Guid)
            .IsRequired()
            .HasMaxLength(36);

        builder.Property(x => x.OrderDetailStatusId)
            .IsRequired();

        builder.HasOne(x => x.OrderDetailStatus)
            .WithMany(x => x.OrderDetails)
            .HasForeignKey(x => x.OrderDetailStatusId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.OrderId)
            .IsRequired()
            .HasMaxLength(55);

        builder.HasOne(x => x.Order)
            .WithMany(x => x.OrderDetails)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.ProductReferenceGuid)
           .IsRequired()
           .HasMaxLength(36);

        builder.HasOne(x => x.ProgramProductReference)
            .WithMany(x => x.OrderDetails)
            .HasForeignKey(x => x.ProductReferenceGuid)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.Property(x => x.UnitPrice).HasPrecision(18, 2)
           .IsRequired();

        builder.Property(x => x.Discount).HasPrecision(18, 2)
           .IsRequired();

        builder.Property(x => x.CreateDate)
           .IsRequired();

    }
}
