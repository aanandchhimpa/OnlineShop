using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Product_confi.Variant_confi
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable("ProductVariants"); // Table name

            builder.HasKey(pv => pv.Id); // Primary Key

            // **Foreign Key Relationship with Product**
            builder.HasOne(pv => pv.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.Cascade); // Delete variants when product is deleted

            builder.Property(pv => pv.AdditionalPrice)
                .HasColumnType("decimal(18,2)"); // Precision for price

            builder.Property(pv => pv.StockQuantity)
                .IsRequired(); // Stock must be defined
        }
    }
}
