using Domain.Entities.Products;

namespace Application.Features.Products_Service.Products.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Guid? BrandId { get; set; }
        public string BrandName { get; set; }
        public bool IsActive { get; set; }
        public decimal BasePrice { get; set; }
        public int StockQuantity { get; set; }
        public List<ProductImageDto> Images { get; set; } = new();
        public List<ProductVariantDto> Variants { get; set; } = new();
    }

    public class ProductImageDto
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
    }

    public class ProductVariantDto
    {
        public Guid Id { get; set; }
        public decimal? AdditionalPrice { get; set; }
        public int StockQuantity { get; set; }
        public List<ProductVariantAttributeDto> Attributes { get; set; } = new();
    }

    public class ProductVariantAttributeDto
    {
        public Guid AttributeId { get; set; }
        public string AttributeName { get; set; }
        public string Value { get; set; }
    }
}