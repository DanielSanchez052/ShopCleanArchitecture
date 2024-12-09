using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.ShopCart;

namespace Shop.Infrastructure.ShopCart.Configuration;

internal class CartEntityConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable(nameof(Cart), Schemas.ShopCart);

        builder.HasKey(x => x.Guid);

        builder.Property(a => a.Guid)
            .IsRequired()
            .HasMaxLength(36);

        builder.Property(a => a.CreateDate)
            .IsRequired();

        builder.Property(a => a.IsActive)
            .IsRequired();

        builder.HasOne(x => x.Account)
            .WithMany(a => a.Carts)
            .HasForeignKey(x => x.AccountGuid);
    }
}
