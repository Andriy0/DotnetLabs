using AutoMapper;
using DotnetLabs.Models;
using DotnetLabs.Services.Products;
using DotnetLabs.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotnetLabs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IMapper mapper, IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<ProductViewModel>> Get()
    {
        var products = await mediator.Send(new GetAllProductsQuery());
        
        return mapper.Map<IEnumerable<ProductViewModel>>(products);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var product = await mediator.Send(new GetProductQuery { Id = id });
        if (product == null) return NotFound();
        
        return Ok(mapper.Map<ProductViewModel>(product));
    }
    
    [HttpGet("{title}")]
    public async Task<IActionResult> Get(string title)
    {
        var product = await mediator.Send(new GetProductByTitleQuery() { Title = title});
        if (product == null) return NotFound();
        
        return Ok(mapper.Map<ProductViewModel>(product));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateProductViewModel productVm)
    {
        var command = new CreateProductCommand { Product = mapper.Map<Product>(productVm) };
        var product = await mediator.Send(command);
        
        return Ok(mapper.Map<ProductCreatedViewModel>(product));
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, UpdateProductViewModel productVm)
    {
        if (id != productVm.Id) { return BadRequest(); }

        var command = new UpdateProductCommand { Product = mapper.Map<Product>(productVm) };
        var product = await mediator.Send(command);
        
        return Ok(mapper.Map<ProductCreatedViewModel>(product));
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await mediator.Send(new DeleteProductCommand { Id = id });
        if (product == null) return NotFound();
        
        return Ok(mapper.Map<ProductCreatedViewModel>(product));
    }
}
