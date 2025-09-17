using Application.Features.Products_Service.Products.DTOs;
using Application.Interfaces.Repositories.Common;
using Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Pagination_Result;

namespace Application.Features.Products_Service.Products.Queries.GetAllQuery
{
    public class GetAllProductsQuery : IRequest<Result<List<ProductDto>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? SearchTerm { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? BrandId { get; set; }
        public bool? IsActive { get; set; }
    }

    internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Result<List<ProductDto>>>
    {
        private readonly IUnitofWork _unitOfWork;

        public GetAllProductsQueryHandler(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _unitOfWork.Repository<Product>().GetQueryable()
                    .Include(p => p.Category)
                    .Include(p => p.Brand)
                    .Include(p => p.Images)
                    .Include(p => p.Variants)
                        .ThenInclude(v => v.VariantAttributes)
                    .AsQueryable();

                // Apply filters
                if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                {
                    query = query.Where(p => p.Name.Contains(request.SearchTerm) || 
                                           p.Description.Contains(request.SearchTerm));
                }

                if (request.CategoryId.HasValue)
                {
                    query = query.Where(p => p.CategoryId == request.CategoryId);
                }

                if (request.BrandId.HasValue)
                {
                    query = query.Where(p => p.BrandId == request.BrandId);
                }

                if (request.IsActive.HasValue)
                {
                    query = query.Where(p => p.IsActive == request.IsActive);
                }

                // Apply pagination
                if (request.PageNumber.HasValue && request.PageSize.HasValue)
                {
                    query = query.Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                                .Take(request.PageSize.Value);
                }

                var products = await query.ToListAsync(cancellationToken);

                var productDtos = products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Slug = p.Slug,
                    Description = p.Description,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category?.Name,
                    BrandId = p.BrandId,
                    BrandName = p.Brand?.Name,
                    IsActive = p.IsActive,
                    BasePrice = p.BasePrice,
                    StockQuantity = p.StockQuantity,
                    Images = p.Images.Select(i => new ProductImageDto
                    {
                        Id = i.Id,
                        ImageUrl = i.ImageUrl,
                        IsPrimary = i.IsPrimary
                    }).ToList(),
                    Variants = p.Variants.Select(v => new ProductVariantDto
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
                }).ToList();

                return Result<List<ProductDto>>.Success(productDtos);
            }
            catch (Exception ex)
            {
                return Result<List<ProductDto>>.Failure($"Internal server error: {ex.Message}");
            }
        }
    }
}