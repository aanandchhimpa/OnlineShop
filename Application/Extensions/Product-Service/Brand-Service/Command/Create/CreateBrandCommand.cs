using Application.Interfaces.Repositories.Common;
using AutoMapper;
using Domain.Entities.Brands;
using MediatR;
using Shared.Pagination_Result;

namespace Application.Extensions.Product_Service.Brand_Service.Command.Create
{
    public record CreateBrandCommand:IRequest<Result<Guid>>
    {
        public string Name { get; set; } // Brand name
        public string Slug { get; set; } // SEO-Friendly URL
        public string Description { get; set; }
    }

    internal class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Result<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitofWork _unitofWork;
        public CreateBrandCommandHandler(IMapper mapper, IUnitofWork unitofWork)
        {
             _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public async Task<Result<Guid>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var mapData = _mapper.Map<Brand>(request);
            await _unitofWork.Brand.AddAsync(mapData);
            await _unitofWork.SaveChangesAsync();
            return Result<Guid>.Success(mapData.Id);        
        }
    }
}
