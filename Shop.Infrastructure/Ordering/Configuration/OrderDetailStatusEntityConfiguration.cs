using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Ordering;

namespace Shop.Infrastructure.Ordering.Configuration;

public class OrderDetailStatusEntityConfiguration : IEntityTypeConfiguration<OrderDetailStatus>
{
    public void Configure(EntityTypeBuilder<OrderDetailStatus> builder)
    {
        builder.ToTable(nameof(OrderDetailStatus), Schemas.Ordering);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.IsActive)
            .IsRequired();
    }
}
