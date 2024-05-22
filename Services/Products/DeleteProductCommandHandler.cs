using DotnetLabs.Data.Repositories;
using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Products;

public class DeleteProductCommandHandler(ProductRepository repository)
    : IRequestHandler<DeleteProductCommand, Product>
{
    public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        return await repository.Delete(request.Id);
    }
}
