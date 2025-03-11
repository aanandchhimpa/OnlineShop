using Domain.Common;
using Domain.Entities.Brands;
using Domain.Entities.Categories;
using Domain.Entities.DynamicFilters;

namespace Domain.Entities.Products
{
    public class Product : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int? BrandId { get; set; }
        public virtual Brand Brand { get; set; } // New: Product belongs to a brand
        public bool IsActive { get; set; } = true;
        public decimal BasePrice { get; set; }
        public int StockQuantity { get; set; }
        public virtual ICollection<ProductFilter> ProductFilters { get; set; } = new List<ProductFilter>();
        public virtual ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public virtual ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
        public virtual ICollection<ProductAttributeMapping> Attributes { get; set; } = new List<ProductAttributeMapping>();
    }


}
