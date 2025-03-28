using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Product_confi.Variant_confi
{

    public class ProductVariantAttributeConfiguration : IEntityTypeConfiguration<ProductVariantAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductVariantAttribute> builder)
        {
            builder.ToTable("ProductVariantAttributes"); // Table name

            builder.HasKey(pva => pva.Id); // Primary Key

            // **Foreign Key Relationship with ProductVariant**
            builder.HasOne(pva => pva.ProductVariant)
                .WithMany(pv => pv.VariantAttributes)
                .HasForeignKey(pva => pva.ProductVariantId)
                .OnDelete(DeleteBehavior.Cascade); // Delete attributes when variant is deleted

            // **Foreign Key Relationship with ProductAttribute**
            builder.HasOne(pva => pva.ProductAttribute)
                .WithMany()
                .HasForeignKey(pva => pva.ProductAttributeId)
                .OnDelete(DeleteBehavior.Cascade); // Delete attribute mappings when attribute is deleted

            // **Foreign Key Relationship with ProductAttributeValue**
            builder.HasOne(pva => pva.ProductAttributeValue)
                .WithMany()
                .HasForeignKey(pva => pva.ProductAttributeValueId)
                .OnDelete(DeleteBehavior.Cascade); // Delete attribute mappings when value is deleted
        }
    }
}
