using Application.Features.Products_Service.Brands.DTOs;
using Application.Interfaces.Repositories.Common;
using Domain.Entities.Brands;
using MediatR;
using Shared.Pagination_Result;

namespace Application.Features.Products_Service.Brands.Queries.GetbyIdQuery
{
    public class GetBrandByIdQuery : IRequest<Result<BrandDto>>
    {
        public Guid Id { get; set; }
        public GetBrandByIdQuery(Guid id) { Id = id; }
    }

    internal class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, Result<BrandDto>>
    {
        private readonly IUnitofWork _unitOfWork;
        public GetBrandByIdQueryHandler(IUnitofWork unitOfWork) { _unitOfWork = unitOfWork; }
        public async Task<Result<BrandDto>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var brand = await _unitOfWork.Repository<Brand>().GetByIdAsync(request.Id);
                if (brand == null)
                    return Result<BrandDto>.Failure("Brand not found.");
                var dto = new BrandDto
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    Slug = brand.Slug,
                    Description = brand.Description
                };
                return Result<BrandDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return Result<BrandDto>.Failure($"Internal server error: {ex.Message}");
            }
        }
    }
}