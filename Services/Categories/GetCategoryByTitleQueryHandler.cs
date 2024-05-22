using DotnetLabs.Data.Repositories;
using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Categories;

public class GetCategoryByTitleQueryHandler(CategoryRepository categoryRepository)
    : IRequestHandler<GetCategoryByTitleQuery, Category>
{
    public async Task<Category> Handle(GetCategoryByTitleQuery request, CancellationToken cancellationToken)
    {
        return await categoryRepository.GetByTitle(request.Title);
    }
}
