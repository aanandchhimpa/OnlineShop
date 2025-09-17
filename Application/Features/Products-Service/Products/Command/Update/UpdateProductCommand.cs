using Application.Interfaces.Repositories.Common;
using Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Pagination_Result;

namespace Application.Features.Products_Service.Products.Command.Update
{
    public class UpdateProductCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? BrandId { get; set; }
        public decimal BasePrice { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
        public List<ProductImageUpdateDto> Images { get; set; } = new();
        public List<ProductVariantUpdateDto> Variants { get; set; } = new();
    }

    public class ProductImageUpdateDto
    {
        public Guid? Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
    }

    public class ProductVariantUpdateDto
    {
        public Guid? Id { get; set; }
        public decimal? AdditionalPrice { get; set; }
        public int StockQuantity { get; set; }
        public List<ProductVariantAttributeUpdateDto> Attributes { get; set; } = new();
    }

    public class ProductVariantAttributeUpdateDto
    {
        public Guid? Id { get; set; }
        public Guid ProductAttributeId { get; set; }
        public Guid ProductAttributeValueId { get; set; }
    }

    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<bool>>
    {
        private readonly IUnitofWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _unitOfWork.Repository<Product>().GetQueryable()
                    .Include(p => p.Images)
                    .Include(p => p.Variants)
                        .ThenInclude(v => v.VariantAttributes)
                    .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                if (product == null)
                    return Result<bool>.Failure("Product not found.");

                // Update basic properties
                product.Name = request.Name;
                product.Description = request.Description;
                product.Slug = request.Slug;
                product.CategoryId = request.CategoryId;
                product.BrandId = request.BrandId;
                product.BasePrice = request.BasePrice;
                product.StockQuantity = request.StockQuantity;
                product.IsActive = request.IsActive;

                // Update images
                var existingImageIds = request.Images.Where(i => i.Id.HasValue).Select(i => i.Id.Value).ToList();
                var imagesToRemove = product.Images.Where(i => !existingImageIds.Contains(i.Id)).ToList();
                foreach (var image in imagesToRemove)
                {
                    product.Images.Remove(image);
                }

                foreach (var imageDto in request.Images)
                {
                    if (imageDto.Id.HasValue)
                    {
                        var existingImage = product.Images.FirstOrDefault(i => i.Id == imageDto.Id);
                        if (existingImage != null)
                        {
                            existingImage.ImageUrl = imageDto.ImageUrl;
                            existingImage.IsPrimary = imageDto.IsPrimary;
                        }
                    }
                    else
                    {
                        product.Images.Add(new ProductImage
                        {
                            ImageUrl = imageDto.ImageUrl,
                            IsPrimary = imageDto.IsPrimary
                        });
                    }
                }

                // Update variants
                var existingVariantIds = request.Variants.Where(v => v.Id.HasValue).Select(v => v.Id.Value).ToList();
                var variantsToRemove = product.Variants.Where(v => !existingVariantIds.Contains(v.Id)).ToList();
                foreach (var variant in variantsToRemove)
                {
                    product.Variants.Remove(variant);
                }

                foreach (var variantDto in request.Variants)
                {
                    if (variantDto.Id.HasValue)
                    {
                        var existingVariant = product.Variants.FirstOrDefault(v => v.Id == variantDto.Id);
                        if (existingVariant != null)
                        {
                            existingVariant.AdditionalPrice = variantDto.AdditionalPrice;
                            existingVariant.StockQuantity = variantDto.StockQuantity;

                            // Update variant attributes
                            var existingAttrIds = variantDto.Attributes.Where(a => a.Id.HasValue).Select(a => a.Id.Value).ToList();
                            var attrsToRemove = existingVariant.VariantAttributes.Where(a => !existingAttrIds.Contains(a.Id)).ToList();
                            foreach (var attr in attrsToRemove)
                            {
                                existingVariant.VariantAttributes.Remove(attr);
                            }

                            foreach (var attrDto in variantDto.Attributes)
                            {
                                if (attrDto.Id.HasValue)
                                {
                                    var existingAttr = existingVariant.VariantAttributes.FirstOrDefault(a => a.Id == attrDto.Id);
                                    if (existingAttr != null)
                                    {
                                        existingAttr.ProductAttributeId = attrDto.ProductAttributeId;
                                        existingAttr.ProductAttributeValueId = attrDto.ProductAttributeValueId;
                                    }
                                }
                                else
                                {
                                    existingVariant.VariantAttributes.Add(new ProductVariantAttribute
                                    {
                                        ProductAttributeId = attrDto.ProductAttributeId,
                                        ProductAttributeValueId = attrDto.ProductAttributeValueId
                                    });
                                }
                            }
                        }
                    }
                    else
                    {
                        var newVariant = new ProductVariant
                        {
                            AdditionalPrice = variantDto.AdditionalPrice,
                            StockQuantity = variantDto.StockQuantity
                        };

                        foreach (var attrDto in variantDto.Attributes)
                        {
                            newVariant.VariantAttributes.Add(new ProductVariantAttribute
                            {
                                ProductAttributeId = attrDto.ProductAttributeId,
                                ProductAttributeValueId = attrDto.ProductAttributeValueId
                            });
                        }

                        product.Variants.Add(newVariant);
                    }
                }

                _unitOfWork.Repository<Product>().Update(product);
                await _unitOfWork.SaveChangesAsync();

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Internal server error: {ex.Message}");
            }
        }
    }
}