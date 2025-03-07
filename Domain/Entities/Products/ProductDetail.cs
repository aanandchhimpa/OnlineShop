using Domain.Common;
using Domain.Entities.Categories;

namespace Domain.Entities.Products
{
    public class ProductDetail : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

        // public ProductType ProductType { get; set; }
        public Category Category { get; set; }
        // public SubCategory SubCategory { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }

}

