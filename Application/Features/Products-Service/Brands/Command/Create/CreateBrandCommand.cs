using Application.Interfaces.Repositories.Common;
using Domain.Entities.Brands;
using MediatR;
using Shared.Pagination_Result;

namespace Application.Features.Products_Service.Brands.Command.Create
{
    public class CreateBrandCommand : IRequest<Result<Guid>>
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
    }

    internal class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Result<Guid>>
    {
        private readonly IUnitofWork _unitOfWork;
        public CreateBrandCommandHandler(IUnitofWork unitOfWork) { _unitOfWork = unitOfWork; }
        public async Task<Result<Guid>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var brand = new Brand
                {
                    Name = request.Name,
                    Slug = request.Slug,
                    Description = request.Description
                };
                await _unitOfWork.Repository<Brand>().AddAsync(brand);
                await _unitOfWork.SaveChangesAsync();
                return Result<Guid>.Success(brand.Id);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure($"Internal server error: {ex.Message}");
            }
        }
    }
}