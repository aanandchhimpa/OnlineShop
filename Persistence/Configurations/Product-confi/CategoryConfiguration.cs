using Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Product_confi
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories"); // Table name in DB

            builder.HasKey(c => c.Id); // Primary Key

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100); // Required & Max Length

            builder.Property(c => c.Slug)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(c => c.Slug)
                .IsUnique(); // Unique constraint on Slug

            builder.Property(c => c.Description)
                .HasMaxLength(500);

            // **Self-referencing relationship for Parent-Child Categories**
            builder.HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // **One-to-Many relationship with Product**
            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete for products
        }
    }
}
