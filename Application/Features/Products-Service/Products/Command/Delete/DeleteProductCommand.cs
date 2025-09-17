using Application.Interfaces.Repositories.Common;
using Domain.Entities.Products;
using MediatR;
using Shared.Pagination_Result;

namespace Application.Features.Products_Service.Products.Command.Delete
{
    public class DeleteProductCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; set; }

        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }

    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<bool>>
    {
        private readonly IUnitofWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _unitOfWork.Repository<Product>().GetByIdAsync(request.Id);
                if (product == null)
                    return Result<bool>.Failure("Product not found.");

                _unitOfWork.Repository<Product>().Delete(product);
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