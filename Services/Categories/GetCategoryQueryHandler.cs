using DotnetLabs.Data;
using DotnetLabs.Data.Repositories;
using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Categories;

public class GetCategoryQueryHandler(CategoryRepository categoryRepository) 
    : IRequestHandler<GetCategoryQuery, Category>
{
    public async Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        return await categoryRepository.Get(request.Id);
    }
}
