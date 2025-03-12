using Domain.Common;
using Domain.Entities.Categories;
using Domain.Entities.Products;

namespace Domain.Entities.Website
{
    public class MenuItem : BaseAuditableEntity
    {
        public string Title { get; set; } // Display name (e.g., "Home", "Shop", "Electronics")
        public string Url { get; set; } // Dynamic URL (e.g., "/shop/electronics")
        public int? ParentId { get; set; } // Self-referencing for nested menus
        public MenuItem Parent { get; set; }
        public ICollection<MenuItem> SubMenus { get; set; } = new List<MenuItem>();
        public int DisplayOrder { get; set; } // Order in the menu
        public string IconClass { get; set; } // Optional icon
        public bool IsActive { get; set; } // Active/inactive
        public int? WebsiteContentId { get; set; } // Link to dynamic pages
        public WebsiteContent WebsiteContent { get; set; }
        public int? CategoryId { get; set; } // 🔹 Link to product category
        public Category Category { get; set; }
        public int? ProductId { get; set; } // 🔹 Link to a specific product (optional)
        public Product Product { get; set; }
    }


}
