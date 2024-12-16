using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Config;

namespace Shop.Infrastructure.Config.Configuration;

public class ProgramEntityConfiguration : IEntityTypeConfiguration<Program>
{
    public void Configure(EntityTypeBuilder<Program> builder)
    {
        builder.ToTable(nameof(Program), Schemas.Config);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .IsRequired()
           .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Slug)
           .IsRequired()
           .HasMaxLength(255);

        builder.Property(x => x.IsActive).IsRequired();
    }
}
