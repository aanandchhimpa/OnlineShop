using Domain.Common;

namespace Domain.Entities.Products
{
    public class ProductAttribute : BaseAuditableEntity
    {
        public string Name { get; set; } // E.g., "Color", "Size", "Material"
        public ICollection<ProductAttributeValue> AttributeValues { get; set; } = new List<ProductAttributeValue>();
    }

}
