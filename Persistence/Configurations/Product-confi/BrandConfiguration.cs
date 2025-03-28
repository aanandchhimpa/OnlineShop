using Domain.Entities.Brands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Product_confi
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands"); // Table name in DB

            builder.HasKey(b => b.Id); // Primary Key

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100); // Required & Max Length

            builder.Property(b => b.Slug)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(b => b.Slug)
                .IsUnique(); // Unique constraint on Slug

            builder.Property(b => b.Description)
                .HasMaxLength(500);

            // **One-to-Many relationship with Product**
            builder.HasMany(b => b.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete products when a brand is deleted
        }
    }
}
