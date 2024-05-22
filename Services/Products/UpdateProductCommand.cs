using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Products;

public class UpdateProductCommand : IRequest<Product>
{
    public Product Product { get; set; }
}
