using Application.Features.Products_Service.Products.DTOs;
using Application.Interfaces.Repositories.Common;
using Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Pagination_Result;

namespace Application.Features.Products_Service.Products.Queries.GetByIdQuery
{
    public class GetProductByIdQuery : IRequest<Result<ProductDto>>
    {
        public Guid Id { get; set; }

        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductDto>>
    {
        private readonly IUnitofWork _unitOfWork;

        public GetProductByIdQueryHandler(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _unitOfWork.Repository<Product>().GetQueryable()
                    .Include(p => p.Category)
                    .Include(p => p.Brand)
                    .Include(p => p.Images)
                    .Include(p => p.Variants)
                        .ThenInclude(v => v.VariantAttributes)
                    .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                if (product == null)
                    return Result<ProductDto>.Failure("Product not found.");

                var productDto = new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Slug = product.Slug,
                    Description = product.Description,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category?.Name,
                    BrandId = product.BrandId,
                    BrandName = product.Brand?.Name,
                    IsActive = product.IsActive,
                    BasePrice = product.BasePrice,
                    StockQuantity = product.StockQuantity,
                    Images = product.Images.Select(i => new ProductImageDto
                    {
                        Id = i.Id,
                        ImageUrl = i.ImageUrl,
                        IsPrimary = i.IsPrimary
                    }).ToList(),
                    Variants = product.Variants.Select(v => new ProductVariantDto
                    {
                        Id = v.Id,
                        AdditionalPrice = v.AdditionalPrice,
                        StockQuantity = v.StockQuantity,
                        Attributes = v.VariantAttributes.Select(va => new ProductVariantAttributeDto
                        {
                            AttributeId = va.Id,
                            AttributeName = va.ProductAttribute?.Name,
                            Value = va.ProductAttributeValue?.Value
                        }).ToList()
                    }).ToList()
                };

                return Result<ProductDto>.Success(productDto);
            }
            catch (Exception ex)
            {
                return Result<ProductDto>.Failure($"Internal server error: {ex.Message}");
            }
        }
    }
}