using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Customer;

namespace Shop.Infrastructure.Customer.Configuration;

public class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(nameof(Address), Schemas.Customer);
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.AccountGuid)
            .IsRequired()
            .HasMaxLength(36);

        builder.HasOne(x => x.Account)
            .WithMany(x => x.Addresses)
            .HasForeignKey(x => x.AccountGuid)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.Street)
            .IsRequired(false)
            .HasMaxLength(256);
        
        builder.Property(x => x.City)
            .IsRequired(false)
            .HasMaxLength(256);
        
        builder.Property(x => x.State)
            .IsRequired(false)
            .HasMaxLength(256);

        builder.Property(x => x.Country)
            .IsRequired(false)
            .HasMaxLength(256);

        builder.Property(x => x.ZipCode)
            .IsRequired(false)
            .HasMaxLength(256);

        builder.Property(x => x.HouseNumber)
            .IsRequired(false)
            .HasMaxLength(256);

        builder.Property(x => x.RawValue).HasMaxLength(256);

        builder.Property(x => x.IsDefault)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();
    }
}
