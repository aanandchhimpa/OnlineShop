using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Product_confi.Attribute_confi
{
    public class ProductAttributeValueConfiguration : IEntityTypeConfiguration<ProductAttributeValue>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
        {
            builder.ToTable("ProductAttributeValues"); // Table name

            builder.HasKey(pav => pav.Id); // Primary Key

            builder.Property(pav => pav.Value)
                .IsRequired()
                .HasMaxLength(200); // Example: "Red", "Large", "Intel i7"

            // **Foreign Key Relationship with ProductAttribute**
            builder.HasOne(pav => pav.ProductAttribute)
                .WithMany(pa => pa.AttributeValues)
                .HasForeignKey(pav => pav.ProductAttributeId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete attribute values
        }
    }
}
