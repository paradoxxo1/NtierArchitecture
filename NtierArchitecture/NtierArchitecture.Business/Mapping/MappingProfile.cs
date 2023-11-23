using AutoMapper;
using NtierArchitecture.Business.Features.Categories.CreateCategory;
using NtierArchitecture.Business.Features.Categories.UpdateCategory;
using NtierArchitecture.Business.Features.Products.CreateProduct;
using NtierArchitecture.Business.Features.Products.UpdateProduct;
using NtierArchitecture.Entities.Models;

namespace NtierArchitecture.Business.Mapping
{
    internal sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
        }
    }
}
