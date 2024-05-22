using DotnetLabs.Data.Repositories;
using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Products;

public class CreateProductCommandHandler(ProductRepository repository)
    : IRequestHandler<CreateProductCommand, Product>
{
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        return await repository.Add(request.Product);
    }
}
