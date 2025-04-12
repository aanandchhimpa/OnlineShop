using Domain.Common;

namespace Domain.Entities.AuditLogs
{
    public class AuditLog : BaseAuditableEntity
    {
        public string EntityName { get; set; } // e.g., "Product", "Category"
        public Guid EntityId { get; set; }
        public string Action { get; set; } // e.g., "Created", "Updated", "Deleted"
        public string Changes { get; set; } // Store old and new values
        public Guid UserId { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
