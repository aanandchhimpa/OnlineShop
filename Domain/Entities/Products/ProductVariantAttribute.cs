using Domain.Common;

namespace Domain.Entities.Products
{
    public class ProductVariantAttribute : BaseAuditableEntity
    {
        public Guid ProductVariantId { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }

        public Guid ProductAttributeId { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }

        public Guid ProductAttributeValueId { get; set; }
        public virtual ProductAttributeValue ProductAttributeValue { get; set; }
    }
}
