using Domain.Common;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entities.Account
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public int TenantId { get; set; } // For multi-tenancy
        public ICollection<UserRole> Roles { get; set; }
    }

    public class UserRole : BaseAuditableEntity
    {
        public string RoleName { get; set; } // e.g., Admin, Seller, Customer
        public ICollection<Permission> Permissions { get; set; }
    }

    public class Permission : BaseAuditableEntity
    {
        public string Action { get; set; } // e.g., "ViewProducts", "EditCategories"
        public string Resource { get; set; } // e.g., "Products", "Categories"
    }

}
