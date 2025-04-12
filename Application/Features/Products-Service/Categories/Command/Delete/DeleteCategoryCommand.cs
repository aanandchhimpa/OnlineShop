using Application.Interfaces.Repositories.Common;
using Domain.Entities.Categories;
using MediatR;
using Shared.Pagination_Result;

namespace Application.Features.Products_Service.Categories.Command.Delete;


public class DeleteCategoryCommand : IRequest<Result<bool>>
{
    public Guid Id { get; set; }
    public DeleteCategoryCommand(Guid guid)
    {
        Id = guid;
    }
}

internal class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result<bool>>
{
    private readonly IUnitofWork _unitOfWork;

    public DeleteCategoryCommandHandler(IUnitofWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(request.Id);
            if (category == null)
                return Result<bool>.Failure("Category not found.");

             _unitOfWork.Repository<Category>().Delete(category);
            await _unitOfWork.SaveChangesAsync();

            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            return Result<bool>.Failure($"Internal server error: {ex.Message}");
        }
    }
}
