using Application.Interfaces.Repositories.Common;
using Domain.Entities.Categories;
using MediatR;
using Shared.Pagination_Result;

namespace Application.Features.Products_Service.Categories.Command.Update;


public class UpdateCategoryCommand : IRequest<Result<bool>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public Guid? ParentCategoryId { get; set; }
}

internal class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<bool>>
{
    private readonly IUnitofWork _unitOfWork;

    public UpdateCategoryCommandHandler(IUnitofWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(request.Id);
            if (category == null)
                return Result<bool>.Failure("Category not found.");

            category.Name = request.Name;
            category.Description = request.Description;
            category.Slug = request.Slug;
            category.ParentCategoryId = request.ParentCategoryId;
             _unitOfWork.Repository<Category>().Update(category);
            await _unitOfWork.SaveChangesAsync();

            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            return Result<bool>.Failure($"Internal server error: {ex.Message}");
        }
    }
}
