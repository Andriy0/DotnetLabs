using AutoMapper;
using DotnetLabs.Models;
using DotnetLabs.ViewModels;

namespace DotnetLabs.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryViewModel>()
            .ReverseMap();
        
        CreateMap<Category, CreateCategoryViewModel>()
            .ReverseMap();
        
        CreateMap<Category, UpdateCategoryViewModel>()
            .ReverseMap();
    }
}
