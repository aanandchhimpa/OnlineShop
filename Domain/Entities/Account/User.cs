using Domain.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Text.Json.Serialization;

namespace Domain.Entities.Account
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string ProfilePictureUrl { get; set; } // User profile image
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } // Male, Female, Other
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; } // Stored securely

        public string UserName { get; set; }
        public bool IsActive { get; set; } = true; // Account status
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Relationships
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
        public virtual UserProfile Profile { get; set; }
    }


    public class UserRole : BaseAuditableEntity
    {
        public string RoleName { get; set; } // Admin, Seller, Customer
        public virtual ICollection<User> Users { get; set; } = new List<User>();
        public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }


    public class Permission : BaseAuditableEntity
    {
        public string Action { get; set; } // e.g., "ViewProducts", "EditCategories"
        public string Resource { get; set; } // e.g., "Products", "Orders"
    }


}
