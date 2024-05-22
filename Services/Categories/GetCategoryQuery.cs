using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Categories;

public class GetCategoryQuery : IRequest<Category>
{
    public int Id { get; set; }
}
