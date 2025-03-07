using Domain.Common;

namespace Domain.Entities.Website
{
    public class WebsiteContent : BaseAuditableEntity
    {
        public string Key { get; set; } // A unique key to identify the content (e.g., "AboutUs", "ContactUs", "PrivacyPolicy")
        public string Title { get; set; } // Title of the page or content (e.g., "About Us")
        public string Content { get; set; } // HTML or plain text content
        public string MetaDescription { get; set; } // For SEO purposes
        public string MetaKeywords { get; set; } // For SEO keywords
    }

}
