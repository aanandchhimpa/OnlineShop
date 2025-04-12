using Domain.Common;

namespace Domain.Entities.Products
{
    public class ProductAttributeValue : BaseAuditableEntity
    {
        public Guid ProductAttributeId { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }

        public string Value { get; set; } // Example: "Red", "Large", "Intel i7"
    }



}
