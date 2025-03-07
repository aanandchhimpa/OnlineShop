using Domain.Common;
using Domain.Entities.Products;

namespace Domain.Entities.Categories
{
    public class Category : BaseAuditableEntity
    {
        public string Name { get; set; } // e.g., "Men", "Footwear", "Casual Shoes"
        public string Description { get; set; }
        public int? ParentCategoryId { get; set; } // Self-referencing for nested categories
        public Category ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ICollection<ProductDetail> Products { get; set; } = new List<ProductDetail>();
    }


}
