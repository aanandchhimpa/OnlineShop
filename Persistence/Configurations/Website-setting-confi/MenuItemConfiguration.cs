using Domain.Entities.Website;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Website_setting_confi;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.ToTable("MenuItems"); 

        builder.HasKey(mi => mi.Id);

        builder.Property(mi => mi.Title)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(mi => mi.Url)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(mi => mi.IconClass)
            .HasMaxLength(100);

        builder.Property(mi => mi.DisplayOrder)
            .IsRequired();

        builder.Property(mi => mi.IsActive)
            .IsRequired();

        // 🔹 Self-referencing relationship for nested menus
        builder.HasOne(mi => mi.Parent)
            .WithMany(mi => mi.SubMenus)
            .HasForeignKey(mi => mi.ParentId)
            .OnDelete(DeleteBehavior.Restrict); // Prevents cascading deletes for safety

        // 🔹 Relationship with WebsiteContent
        builder.HasOne(mi => mi.WebsiteContent)
            .WithMany()
            .HasForeignKey(mi => mi.WebsiteContentId)
            .OnDelete(DeleteBehavior.SetNull); // If content is deleted, the menu remains

        // 🔹 Relationship with Category
        builder.HasOne(mi => mi.Category)
            .WithMany()
            .HasForeignKey(mi => mi.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        // 🔹 Relationship with Product
        builder.HasOne(mi => mi.Product)
            .WithMany()
            .HasForeignKey(mi => mi.ProductId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
