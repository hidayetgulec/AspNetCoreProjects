using AspNetCoreMvc_DependencyInjection.Models;
using AspNetCoreMvc_DependencyInjection.ViewModels;
using AutoMapper;

namespace AspNetCoreMvc_DependencyInjection.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
