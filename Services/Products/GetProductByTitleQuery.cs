using DotnetLabs.Data.Repositories;
using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Products;

public class GetProductByTitleQuery : IRequest<Product>
{
    public string Title { get; set; }
}
