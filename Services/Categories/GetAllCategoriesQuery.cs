using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Categories;

public class GetAllCategoriesQuery : IRequest<List<Category>>
{
}
