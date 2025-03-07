using Domain.Common;

namespace Domain.Entities.Products
{
    public class ProductAttributeValue : BaseAuditableEntity
    {
        public int ProductAttributeId { get; set; }
        public ProductAttribute ProductAttribute { get; set; }

        public string Value { get; set; } // E.g., "Red", "Large"
    }


}
