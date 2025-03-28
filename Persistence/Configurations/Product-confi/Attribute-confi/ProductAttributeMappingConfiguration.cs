using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Product_confi.Attribute_confi;


public class ProductAttributeMappingConfiguration : IEntityTypeConfiguration<ProductAttributeMapping>
{
    public void Configure(EntityTypeBuilder<ProductAttributeMapping> builder)
    {
        builder.ToTable("ProductAttributeMappings"); // Table name

        builder.HasKey(pam => pam.Id); // Primary Key

        // **Foreign Key Relationship with Product**
        builder.HasOne(pam => pam.Product)
            .WithMany(p => p.Attributes)
            .HasForeignKey(pam => pam.ProductId)
            .OnDelete(DeleteBehavior.Cascade); // Delete mappings when product is deleted

        // **Foreign Key Relationship with ProductAttribute**
        builder.HasOne(pam => pam.ProductAttribute)
            .WithMany()
            .HasForeignKey(pam => pam.ProductAttributeId)
            .OnDelete(DeleteBehavior.Cascade); // Delete mappings when attribute is deleted

        // **Foreign Key Relationship with ProductAttributeValue**
        builder.HasOne(pam => pam.ProductAttributeValue)
            .WithMany()
            .HasForeignKey(pam => pam.ProductAttributeValueId)
            .OnDelete(DeleteBehavior.Cascade); // Delete mappings when attribute value is deleted
    }
}
