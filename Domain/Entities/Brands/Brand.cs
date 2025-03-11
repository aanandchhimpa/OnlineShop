using Domain.Common;
using Domain.Entities.Products;

namespace Domain.Entities.Brands
{
    public class Brand : BaseAuditableEntity
    {
        public string Name { get; set; } // Brand name
        public string Slug { get; set; } // SEO-Friendly URL
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }

}
