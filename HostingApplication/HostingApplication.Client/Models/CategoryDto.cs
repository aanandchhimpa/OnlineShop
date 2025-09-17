namespace HostingApplication.Client.Models
{
    public class CategoryDto
    {
        public Guid Id { get; set; } = Guid.Empty;  // Default for new category
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public Guid? ParentCategoryId { get; set; }
        public bool IsActive { get; set; } = true;  // To enable/disable categories
    }

}
