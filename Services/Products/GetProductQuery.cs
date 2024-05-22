using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Products;

public class GetProductQuery : IRequest<Product>
{
    public int Id { get; set; }
}
