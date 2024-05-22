using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Products;

public class CreateProductCommand : IRequest<Product>
{
    public Product Product { get; set; }
}
