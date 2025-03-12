using Domain.Common;

namespace Domain.Entities.Website
{
    public class WebsiteContent : BaseAuditableEntity
    {
        public string Key { get; set; } // Unique identifier (e.g., "AboutUs", "ContactUs", "PrivacyPolicy")
        public string Title { get; set; } // Page title (e.g., "About Us")
        public string Content { get; set; } // HTML or plain text content
        public string MetaDescription { get; set; } // SEO description
        public string MetaKeywords { get; set; } // SEO keywords
        public string PageType { get; set; } // Type of page (e.g., "Static", "LandingPage", "Blog")
    }


}
