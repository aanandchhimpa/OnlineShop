using MediatR;
using Shared.Pagination_Result;

namespace Application.Extensions.Product_Service.Brand_Service.Queries.GetAll
{
    public record GetAllBrandsQuery:IRequest<Result<GetAllBrandsQuery>>
    {

    }
}
