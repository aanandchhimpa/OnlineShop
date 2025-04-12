using Application.Features.Products_Service.Categories.DTOs;
using Application.Interfaces.Repositories.Common;
using Domain.Entities.Categories;
using MediatR;
using Shared.Pagination_Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products_Service.Categories.Queries.GetbyIdQuery
{

    public class GetCategoryByIdQuery : IRequest<Result<CategoryDto>>
    {
        public Guid Id { get; set; }
        public GetCategoryByIdQuery(Guid guid)
        {
            Id = guid;
        }
    }

    internal class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<CategoryDto>>
    {
        private readonly IUnitofWork _unitOfWork;

        public GetCategoryByIdQueryHandler(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _unitOfWork.Repository<Category>().GetByIdAsync(request.Id);
                if (category == null)
                    return Result<CategoryDto>.Failure("Category not found.");

                var categoryDto = new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    Slug = category.Slug,
                    ParentCategoryId = category.ParentCategoryId
                };

                return Result<CategoryDto>.Success(categoryDto);
            }
            catch (Exception ex)
            {
                return Result<CategoryDto>.Failure($"Internal server error: {ex.Message}");
            }
        }
    }
}
