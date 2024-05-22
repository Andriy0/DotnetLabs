using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Categories;

public class DeleteCategoryCommand : IRequest<Category>
{
    public int Id { get; set; }
}
