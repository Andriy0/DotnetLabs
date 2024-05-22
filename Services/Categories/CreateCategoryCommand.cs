using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Categories;

public class CreateCategoryCommand : IRequest<Category>
{
    public string Title { get; set; }
}
