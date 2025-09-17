using Application.Features.Products_Service.Brands.DTOs;
using Application.Interfaces.Repositories.Common;
using Domain.Entities.Brands;
using MediatR;
using Shared.Pagination_Result;

namespace Application.Features.Products_Service.Brands.Queries.GetAllQuery;
public class GetAllBrandsQuery : IRequest<Result<List<BrandDto>>> { }

internal class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, Result<List<BrandDto>>>
{
    private readonly IUnitofWork _unitOfWork;

    public GetAllBrandsQueryHandler(IUnitofWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<List<BrandDto>>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var brands = await _unitOfWork.Repository<Brand>().GetAllAsync();
            var brandDtos = brands.Select(b => new BrandDto
            {
                Id = b.Id,
                Name = b.Name,
                Slug = b.Slug,
                Description = b.Description
            }).ToList();
            return Result<List<BrandDto>>.Success(brandDtos);
        }
        catch (Exception ex)
        {
            return Result<List<BrandDto>>.Failure($"Internal server error: {ex.Message}");
        }
    }
}