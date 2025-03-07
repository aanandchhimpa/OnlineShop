using Domain.Common;

namespace Domain.Entities.Website
{
    public class WebsiteSettings : BaseAuditableEntity
    {
        public string Key { get; set; } // A unique key to identify the setting (e.g., "Logo", "SocialLinks", "HeaderLinks")
        public string Value { get; set; } // JSON or plain text value (e.g., URL of the logo, JSON for social links)
        public string Description { get; set; } // Description of the setting for clarity
    }

}
