using Domain.Common;

namespace Domain.Entities.Content_Versioning
{
    public class ContentVersion : BaseAuditableEntity
    {
        public string Key { get; set; } // e.g., "AboutUs"
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedOn { get; set; } // To show the last update date
    }

}
