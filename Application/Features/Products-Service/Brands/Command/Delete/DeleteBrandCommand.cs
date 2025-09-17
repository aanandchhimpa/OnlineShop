using Application.Interfaces.Repositories.Common;
using Domain.Entities.Brands;
using MediatR;
using Shared.Pagination_Result;

namespace Application.Features.Products_Service.Brands.Command.Delete
{
    public class DeleteBrandCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; set; }
        public DeleteBrandCommand(Guid id) { Id = id; }
    }

    internal class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Result<bool>>
    {
        private readonly IUnitofWork _unitOfWork;
        public DeleteBrandCommandHandler(IUnitofWork unitOfWork) { _unitOfWork = unitOfWork; }
        public async Task<Result<bool>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var brand = await _unitOfWork.Repository<Brand>().GetByIdAsync(request.Id);
                if (brand == null)
                    return Result<bool>.Failure("Brand not found.");
                _unitOfWork.Repository<Brand>().Delete(brand);
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