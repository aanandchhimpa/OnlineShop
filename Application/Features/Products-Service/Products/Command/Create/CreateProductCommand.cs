using Application.Interfaces.Repositories.Common;
using Domain.Entities.Products;
using MediatR;
using Shared.Pagination_Result;

namespace Application.Features.Products_Service.Products.Command.Create
{
    public class CreateProductCommand : IRequest<Result<Guid>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? BrandId { get; set; }
        public decimal BasePrice { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; } = true;
        public List<ProductImageCreateDto> Images { get; set; } = new();
        public List<ProductVariantCreateDto> Variants { get; set; } = new();
    }

    public class ProductImageCreateDto
    {
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
    }

    public class ProductVariantCreateDto
    {
        public decimal? AdditionalPrice { get; set; }
        public int StockQuantity { get; set; }
        public List<ProductVariantAttributeCreateDto> Attributes { get; set; } = new();
    }

    public class ProductVariantAttributeCreateDto
    {
        public Guid ProductAttributeId { get; set; }
        public Guid ProductAttributeValueId { get; set; }
    }

    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Guid>>
    {
        private readonly IUnitofWork _unitOfWork;

        public CreateProductCommandHandler(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = new Product
                {
                    Name = request.Name,
                    Description = request.Description,
                    Slug = request.Slug,
                    CategoryId = request.CategoryId,
                    BrandId = request.BrandId,
                    BasePrice = request.BasePrice,
                    StockQuantity = request.StockQuantity,
                    IsActive = request.IsActive
                };

                // Add images
                foreach (var imageDto in request.Images)
                {
                    product.Images.Add(new ProductImage
                    {
                        ImageUrl = imageDto.ImageUrl,
                        IsPrimary = imageDto.IsPrimary
                    });
                }

                // Add variants
                foreach (var variantDto in request.Variants)
                {
                    var variant = new ProductVariant
                    {
                        AdditionalPrice = variantDto.AdditionalPrice,
                        StockQuantity = variantDto.StockQuantity
                    };

                    foreach (var attrDto in variantDto.Attributes)
                    {
                        variant.VariantAttributes.Add(new ProductVariantAttribute
                        {
                            ProductAttributeId = attrDto.ProductAttributeId,
                            ProductAttributeValueId = attrDto.ProductAttributeValueId
                        });
                    }

                    product.Variants.Add(variant);
                }

                await _unitOfWork.Repository<Product>().AddAsync(product);
                await _unitOfWork.SaveChangesAsync();

                return Result<Guid>.Success(product.Id);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure($"Internal server error: {ex.Message}");
            }
        }
    }
}