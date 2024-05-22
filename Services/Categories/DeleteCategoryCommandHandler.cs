using DotnetLabs.Data.Repositories;
using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Categories;

public class DeleteCategoryCommandHandler(CategoryRepository categoryRepository)
    : IRequestHandler<DeleteCategoryCommand, Category>
{
    public async Task<Category> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        return await categoryRepository.Delete(request.Id);
    }
}
