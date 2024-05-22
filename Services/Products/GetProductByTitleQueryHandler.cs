using DotnetLabs.Data.Repositories;
using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Products;

public class GetProductByTitleQueryHandler(ProductRepository repository)
    : IRequestHandler<GetProductByTitleQuery, Product>
{
    public async Task<Product> Handle(GetProductByTitleQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByTitle(request.Title);
    }
}
