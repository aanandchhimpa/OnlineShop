namespace HostingApplication.Client.Models
{
    public class CategoryDto
    {
        public Guid Id { get; set; } = Guid.Empty;  // Default for new category
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;  // To enable/disable categories
    }

}
