using ADF.Core.Model.Entities;
using ADF.CoreApi.DTOs;
using AutoMapper;

namespace ADF.App.AutoMapper
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductCategoryDto, ProductCategory>();

            CreateMap<ProductCategory, ProductCategoryWithProductDto>();
            CreateMap<ProductCategoryWithProductDto, ProductCategory>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<ProductWithCategoryDto, Product>();
        }
    }
}
