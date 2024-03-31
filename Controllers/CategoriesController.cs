using AutoMapper;
using DotnetLabs.Data;
using DotnetLabs.Models;
using DotnetLabs.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetLabs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(AppDbContext context, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<CategoryViewModel>> Get()
    {
        var categories = await context.Categories.ToListAsync();
        
        return mapper.Map<IEnumerable<CategoryViewModel>>(categories);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> Get(long id)
    {
        var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category == null) return NotFound();
        return Ok(mapper.Map<CategoryViewModel>(category));
    }
    
    [HttpGet("{title}")]
    public async Task<IActionResult> Get(string title)
    {
        var category = await context.Categories.FirstOrDefaultAsync(c => c.Title == title);
        if (category == null) return NotFound();
        return Ok(mapper.Map<CategoryViewModel>(category));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateCategoryViewModel categoryVm)
    {
        var category = mapper.Map<Category>(categoryVm);
        context.Add(category);
        await context.SaveChangesAsync();
        return Ok(category);
    }
    
    [HttpPut("{id:long}")]
    public async Task<IActionResult> Put(long id, CategoryViewModel categoryVm)
    {
        var category = await context.Categories.FindAsync(id);
        if (category == null) return NotFound();
        category.Title = categoryVm.Title;
        await context.SaveChangesAsync();
        return Ok(category);
    }
    
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var category = await context.Categories.FindAsync(id);
        if (category == null) return NotFound();
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
        return Ok(category);
    }
}
