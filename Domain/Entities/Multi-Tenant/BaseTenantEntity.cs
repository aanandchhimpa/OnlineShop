using Domain.Common;
using Domain.Entities.Account;
using Domain.Entities.Website;

namespace Domain.Entities.Multi_Tenant
{
    public class BaseTenantEntity : BaseAuditableEntity
    {
        public int TenantId { get; set; } // Foreign Key for Tenant
        public Tenant Tenant { get; set; }
    }

    public class Tenant : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Domain { get; set; } // Custom domain for the business
        public bool IsActive { get; set; } = true; // Business status

        public virtual ICollection<User> Users { get; set; }
       // public virtual ICollection<Product> Products { get; set; }
       // public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<WebsiteSettings> Settings { get; set; }
    }


}
