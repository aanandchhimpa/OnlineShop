using Application.Features.Products_Service.Categories.DTOs;
using Application.Interfaces.Repositories.Common;
using Domain.Entities.Categories;
using MediatR;
using Shared.Pagination_Result;

namespace Application.Features.Products_Service.Categories.Queries.GetAllQuery;
public class GetAllCategoriesQuery : IRequest<Result<List<CategoryDto>>> { }

internal class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, Result<List<CategoryDto>>>
{
    private readonly IUnitofWork _unitOfWork;

    public GetAllCategoriesQueryHandler(IUnitofWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<List<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var categories = await _unitOfWork.Repository<Category>().GetAllAsync();
            var categoryDtos = categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Slug = c.Slug,
                ParentCategoryId = c.ParentCategoryId
            }).ToList();

            return Result<List<CategoryDto>>.Success(categoryDtos);
        }
        catch (Exception ex)
        {
            return Result<List<CategoryDto>>.Failure($"Internal server error: {ex.Message}");
        }
    }
}
