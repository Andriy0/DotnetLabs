using DotnetLabs.Data.Repositories;
using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Products;

public class UpdateProductCommandHandler(ProductRepository repository)
    : IRequestHandler<UpdateProductCommand, Product>
{
    public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        return await repository.Update(request.Product);
    }
}
