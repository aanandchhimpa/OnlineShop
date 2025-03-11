using Domain.Common;

namespace Domain.Entities.Products
{
    public class ProductAttributeMapping : BaseAuditableEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int ProductAttributeId { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }

        public int ProductAttributeValueId { get; set; }
        public virtual ProductAttributeValue ProductAttributeValue { get; set; }
    }

}
