using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Product_confi
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products"); // Table name

            builder.HasKey(p => p.Id); // Primary Key

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150); // Required & Max Length

            builder.Property(p => p.Slug)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(p => p.Slug)
                .IsUnique(); // Unique Slug

            builder.Property(p => p.Description)
                .HasMaxLength(1000);

            builder.Property(p => p.BasePrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired(); // Price with precision

            builder.Property(p => p.StockQuantity)
                .IsRequired();

            builder.Property(p => p.IsActive)
                .HasDefaultValue(true);

            // **Foreign Key Relationship with Category**
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete products when category is deleted

            // **Foreign Key Relationship with Brand (Nullable)**
            builder.HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.SetNull); // Set brand to null if deleted

            // **One-to-Many Relationship with Product Filters**
            builder.HasMany(p => p.ProductFilters)
                .WithOne(pf => pf.Product)
                .HasForeignKey(pf => pf.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // **One-to-Many Relationship with Product Images**
            builder.HasMany(p => p.Images)
                .WithOne(pi => pi.Product)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // **One-to-Many Relationship with Product Variants**
            builder.HasMany(p => p.Variants)
                .WithOne(pv => pv.Product)
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // **One-to-Many Relationship with Product Attribute Mapping**
            builder.HasMany(p => p.Attributes)
                .WithOne(pa => pa.Product)
                .HasForeignKey(pa => pa.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}