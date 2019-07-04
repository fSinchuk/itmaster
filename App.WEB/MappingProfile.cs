using App.Models;
using App.WEB.ViewModels;
using AutoMapper;

namespace App.WEB
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Products, ProductDTO>().ReverseMap();
            CreateMap<ProductCategories, ProductCategoryDTO>();
            
        }
    }
}
