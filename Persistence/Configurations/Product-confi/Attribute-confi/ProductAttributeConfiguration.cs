using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Product_confi.Attribute_confi;

public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.ToTable("ProductAttributes"); // Table name

        builder.HasKey(pa => pa.Id); // Primary Key

        builder.Property(pa => pa.Name)
            .IsRequired()
            .HasMaxLength(150);

        // **Self-referencing Parent-Child Relationship for Hierarchical Attributes**
        builder.HasOne(pa => pa.ParentAttribute)
            .WithMany(pa => pa.ChildAttributes)
            .HasForeignKey(pa => pa.ParentAttributeId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent deletion if it has children

        // **One-to-Many Relationship with Attribute Values**
        builder.HasMany(pa => pa.AttributeValues)
            .WithOne(pav => pav.ProductAttribute)
            .HasForeignKey(pav => pav.ProductAttributeId)
            .OnDelete(DeleteBehavior.Cascade); // Delete values when attribute is deleted
    }
}
