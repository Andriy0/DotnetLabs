using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Categories;

public class UpdateCategoryCommand : IRequest<Category>
{
    public Category Category { get; set; }
}
