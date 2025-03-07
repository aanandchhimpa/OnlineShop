using Domain.Common;

namespace Domain.Entities.Website
{
    public class MenuItem : BaseAuditableEntity
    {
        public string Title { get; set; } // Display name of the menu item (e.g., "Home", "Shop")
        public string Url { get; set; } // URL to navigate (e.g., "/shop", "/about")
        public int? ParentId { get; set; } // Self-referencing for nested menus
        public MenuItem Parent { get; set; }
        public ICollection<MenuItem> SubMenus { get; set; } = new List<MenuItem>();
        public int DisplayOrder { get; set; } // Order of appearance
    }

}
