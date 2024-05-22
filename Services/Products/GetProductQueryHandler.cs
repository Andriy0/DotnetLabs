using DotnetLabs.Data.Repositories;
using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Products;

public class GetProductQueryHandler(ProductRepository repository) 
    : IRequestHandler<GetProductQuery, Product>
{
    public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        return await repository.Get(request.Id);
    }
}
