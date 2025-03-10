using Domain.Common;

namespace Domain.Entities.Account
{
    public class Address : BaseAuditableEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public bool IsPrimary { get; set; } // Mark as default address
    }

}
