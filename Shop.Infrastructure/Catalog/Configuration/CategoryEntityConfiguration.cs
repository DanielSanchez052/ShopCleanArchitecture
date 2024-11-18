using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Entities.Catalog;

namespace Shop.Infrastructure.Catalog.Configuration;

public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(nameof(Category), Schemas.Catalog);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasMaxLength(255);

        builder.Property(x => x.ImageUrl)
            .HasMaxLength(500);

        builder.Property(x => x.ProgramId)
            .IsRequired();

        builder.HasOne(x => x.Program)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.ProgramId);

        builder.HasOne(x => x.Parent)
            .WithMany(x => x.ChildCategories)
            .HasForeignKey(x => x.ParentId);

        builder.Property(x => x.IsActive)
           .IsRequired();
    }
}
