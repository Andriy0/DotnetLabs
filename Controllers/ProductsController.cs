using AutoMapper;
using DotnetLabs.Data;
using DotnetLabs.Models;
using DotnetLabs.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetLabs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(AppDbContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<ProductViewModel>> Get()
    {
        var products = await context.Products
            .Include(p => p.Category)
            .ToListAsync();
        
        return mapper.Map<IEnumerable<ProductViewModel>>(products);
    }
    
    [HttpGet("{id:long}")]
    public async Task<IActionResult> Get(long id)
    {
        var product = await context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (product == null) return NotFound();
        
        return Ok(mapper.Map<ProductViewModel>(product));
    }
    
    [HttpGet("{title}")]
    public async Task<IActionResult> Get(string title)
    {
        var product = await context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Title == title);
        
        if (product == null) return NotFound();
        
        return Ok(mapper.Map<ProductViewModel>(product));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateProductViewModel productVm)
    {
        var product = mapper.Map<Product>(productVm);
        
        context.Add(product);
        
        await context.SaveChangesAsync();
        
        return Ok(mapper.Map<ProductCreatedViewModel>(product));
    }
    
    [HttpPut("{id:long}")]
    public async Task<IActionResult> Put(long id, CreateProductViewModel productVm)
    {
        var product = await context.Products.FindAsync(id);
        if (product == null) return NotFound();
        product.Title = productVm.Title;
        product.CategoryId = productVm.CategoryId;
        await context.SaveChangesAsync();
        return Ok(mapper.Map<ProductCreatedViewModel>(product));
    }
    
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var product = await context.Products.FindAsync(id);
        if (product == null) return NotFound();
        context.Products.Remove(product);
        await context.SaveChangesAsync();
        return Ok(mapper.Map<ProductCreatedViewModel>(product));
    }
}
