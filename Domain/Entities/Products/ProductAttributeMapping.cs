using Domain.Common;

namespace Domain.Entities.Products
{
    public class ProductAttributeMapping : BaseAuditableEntity
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Guid ProductAttributeId { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }

        public Guid ProductAttributeValueId { get; set; }
        public virtual ProductAttributeValue ProductAttributeValue { get; set; }
    }

}
