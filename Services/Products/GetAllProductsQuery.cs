using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Products;

public class GetAllProductsQuery : IRequest<List<Product>>
{
}
