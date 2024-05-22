using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Categories;

public class GetCategoryByTitleQuery : IRequest<Category>
{
    public string Title { get; set; }
}
