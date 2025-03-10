using Domain.Common;
using Domain.Entities.Categories;

namespace Domain.Entities.Products
{
    public class Product :BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; } // SEO-Friendly URL
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public bool IsActive { get; set; } = true;
        public decimal BasePrice { get; set; } // Default price before variants
        public int StockQuantity { get; set; } // Overall stock

        public virtual ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public virtual ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
        public virtual ICollection<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();
    }

}
