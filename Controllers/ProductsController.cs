using AutoMapper;
using DotnetLabs.Data.Repositories;
using DotnetLabs.Models;
using DotnetLabs.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotnetLabs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(ProductRepository repository, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<ProductViewModel>> Get()
    {
        var products = await repository.GetAll();
        
        return mapper.Map<IEnumerable<ProductViewModel>>(products);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var product = await repository.Get(id);
        if (product == null) return NotFound();
        
        return Ok(mapper.Map<ProductViewModel>(product));
    }
    
    [HttpGet("{title}")]
    public async Task<IActionResult> Get(string title)
    {
        var product = await repository.GetByTitle(title);
        if (product == null) return NotFound();
        
        return Ok(mapper.Map<ProductViewModel>(product));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateProductViewModel productVm)
    {
        var product = mapper.Map<Product>(productVm);
        await repository.Add(product);
        
        return Ok(mapper.Map<ProductCreatedViewModel>(product));
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, UpdateProductViewModel productVm)
    {
        var product = mapper.Map<Product>(productVm);
        if (id != product.Id) { return BadRequest(); }

        await repository.Update(product);
        return Ok(mapper.Map<ProductCreatedViewModel>(product));
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await repository.Delete(id);
        if (product == null) return NotFound();
        
        return Ok(mapper.Map<ProductCreatedViewModel>(product));
    }
}
