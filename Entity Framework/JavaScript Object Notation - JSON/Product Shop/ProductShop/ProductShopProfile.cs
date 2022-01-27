using AutoMapper;
using ProductShop.Dtos.InputModels;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserInputDto, User>();

            CreateMap<ProductInputDto, Product>();

            CreateMap<CategoriesInputDto, Category>();

            CreateMap<CategoriesProductsInputDto, CategoryProduct>();
        }
    }
}
