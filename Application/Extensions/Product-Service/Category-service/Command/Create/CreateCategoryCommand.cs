using Application.Interfaces.Repositories.Common;
using AutoMapper;
using Domain.Entities.Categories;
using MediatR;
using Shared.Pagination_Result;

namespace Application.Extensions.Product_Service.Category_service.Command.Create
{
    public record CreateCategoryCommand : IRequest<Result<Guid>>
    {
        public string Name { get; set; } // e.g., "Men", "Footwear", "Casual Shoes"
        public string Description { get; set; }
        public string Slug { get; set; }
        public int? ParentCategoryId { get; set; } // Self-referencing for nested categories
    }
    internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitofWork;
        public CreateCategoryCommandHandler(IMapper mapper, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }

        public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var mapData = _mapper.Map<Category>(request);
            await _unitofWork.Category.AddAsync(mapData);
            await _unitofWork.SaveChangesAsync();
            return Result<Guid>.Success(mapData.Id);
        }
    }
}
