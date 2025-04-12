using Application.Interfaces.Repositories.Common;
using Domain.Entities.Categories;
using MediatR;
using Shared.Pagination_Result;

namespace Application.Features.Products_Service.Categories.Command.Create
{
    public class CreateCategoryCommand : IRequest<Result<Guid>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }

    internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<Guid>>
    {
        private readonly IUnitofWork _unitofWork;

        public CreateCategoryCommandHandler(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = new Category
                {
                    Name = request.Name,
                    Description = request.Description,
                    Slug = request.Slug,
                    ParentCategoryId = request.ParentCategoryId
                };

                await _unitofWork.Repository<Category>().AddAsync(category);
                await _unitofWork.SaveChangesAsync();
                return Result<Guid>.Success(category.Id);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure($"Internal server error:{ex.Message}");
            }

        }
    }
}
