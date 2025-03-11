using Domain.Common;

namespace Domain.Entities.Products
{
    public class ProductAttribute : BaseAuditableEntity
    {
        public string Name { get; set; }

        public int? ParentAttributeId { get; set; } // For hierarchical attributes
        public virtual ProductAttribute ParentAttribute { get; set; }

        public virtual ICollection<ProductAttribute> ChildAttributes { get; set; } = new List<ProductAttribute>();
        public virtual ICollection<ProductAttributeValue> AttributeValues { get; set; } = new List<ProductAttributeValue>();
    }


}
