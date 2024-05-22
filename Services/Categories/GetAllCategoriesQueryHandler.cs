using DotnetLabs.Data.Repositories;
using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Categories;

public class GetAllCategoriesQueryHandler(CategoryRepository categoryRepository)
    : IRequestHandler<GetAllCategoriesQuery, List<Category>>
{
    public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAll();

        return categories;
    }
}
