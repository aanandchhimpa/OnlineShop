using Application.Interfaces.Repositories.Common;
using Domain.Entities.Brands;
using MediatR;
using Shared.Pagination_Result;

namespace Application.Features.Products_Service.Brands.Command.Update
{
    public class UpdateBrandCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
    }

    internal class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Result<bool>>
    {
        private readonly IUnitofWork _unitOfWork;
        public UpdateBrandCommandHandler(IUnitofWork unitOfWork) { _unitOfWork = unitOfWork; }
        public async Task<Result<bool>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var brand = await _unitOfWork.Repository<Brand>().GetByIdAsync(request.Id);
                if (brand == null)
                    return Result<bool>.Failure("Brand not found.");
                brand.Name = request.Name;
                brand.Slug = request.Slug;
                brand.Description = request.Description;
                _unitOfWork.Repository<Brand>().Update(brand);
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