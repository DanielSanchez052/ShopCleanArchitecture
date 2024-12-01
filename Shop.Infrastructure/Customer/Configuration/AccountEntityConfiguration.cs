using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Customer;

namespace Shop.Infrastructure.Customer.Configuration;

public class AccountEntityConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable(nameof(Account), Schemas.Customer);

        builder.HasKey(x => x.Guid);

        builder.Property(x => x.Guid)
            .IsRequired()
            .HasMaxLength(36);

        builder.Property(x => x.Name).HasMaxLength(155);
        builder.Property(x => x.LastName).HasMaxLength(155);
        builder.Property(x => x.Email).HasMaxLength(255);
        builder.Property(x => x.PhoneNumber).HasMaxLength(155);


        builder.Property(x => x.CreateDate)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

    }
}
