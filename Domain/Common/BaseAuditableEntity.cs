using Domain.Common.Interfaces;

namespace Domain.Common
{
    public class BaseAuditableEntity : IEntity
    {
        public Guid Id { get; set; }
        public Guid CreateEdBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

    }
}
