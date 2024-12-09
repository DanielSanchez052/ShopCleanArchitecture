using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.ShopCart;

namespace Shop.Infrastructure.ShopCart.Configuration;

internal class CartItemEntityConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable(nameof(CartItem), Schemas.ShopCart);

        builder.HasKey(x => x.Guid);

        builder.Property(a => a.Guid)
            .IsRequired()
            .HasMaxLength(36);

        builder.Property(a => a.CartGuid)
           .IsRequired()
           .HasMaxLength(36);

        builder.HasOne(x => x.Cart).WithMany(x => x.CartItems).HasForeignKey(x => x.CartGuid);

        builder.Property(a => a.ReferenceGuid)
           .IsRequired()
           .HasMaxLength(36);

        builder.HasOne(x => x.Reference).WithMany(x => x.Items).HasForeignKey(x => x.ReferenceGuid);
         
        builder.Property(a => a.Name)
           .HasMaxLength(255)
           .IsRequired();

        builder.Property(a => a.Price)
           .IsRequired()
           .HasPrecision(18, 2);

        builder.Property(a => a.Quantity)
           .IsRequired();

    }
}
