using Application.Extensions.Product_Service.Brand_Service.Command.Create;
using Application.Extensions.Product_Service.Category_service.Command.Create;
using AutoMapper;
using Domain.Entities.Brands;
using Domain.Entities.Categories;

namespace Application.Common.Mapping
{
    public class ProfileMap : Profile
    {
        public ProfileMap()
        {
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        }
    }
}
