using AutoMapper;
using DotnetLabs.Models;
using DotnetLabs.ViewModels;

namespace DotnetLabs.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductViewModel>()
            .ReverseMap();
        
        CreateMap<Product, CreateProductViewModel>()
            .ReverseMap();
        
        CreateMap<Product, ProductCreatedViewModel>()
            .ReverseMap();
        
        CreateMap<Product, UpdateProductViewModel>()
            .ReverseMap();
    }
}
