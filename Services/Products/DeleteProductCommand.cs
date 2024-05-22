using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Products;

public class DeleteProductCommand : IRequest<Product>
{
    public int Id { get; set; }
}
