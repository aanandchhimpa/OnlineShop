using Domain.Entities.Account;
using Domain.Entities.AuditLogs;
using Domain.Entities.Brands;
using Domain.Entities.Categories;
using Domain.Entities.Content_Versioning;
using Domain.Entities.DynamicFilters;
using Domain.Entities.Notifications;
using Domain.Entities.Products;
using Domain.Entities.User_Setting;
using Domain.Entities.Website;
using Domain.Entities.Wishlist_and_Reviews;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<WebsiteSettings> WebsiteSettings { get; set; }
        public DbSet<WebsiteContent> WebsiteContents { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<UserActivityLog> UserActivityLogs { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductAttributeMapping> ProductAttributeMappings { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductVariantAttribute> ProductVariantAttributes { get; set; }
        public DbSet<ProductFilter> ProductFilters { get; set; }
        public DbSet<FilterValue> FilterValues { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<ContentVersion> ContentVersion { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);

            // Automatically apply all IEntityTypeConfiguration<T> implementations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
