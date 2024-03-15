using DotnetLabs.Data;
using DotnetLabs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetLabs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Category>> Get()
    {
        return await context.Categories.ToListAsync();
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> Get(long id)
    {
        var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category == null) return NotFound();
        return Ok(category);
    }
    
    [HttpGet("{title}")]
    public async Task<IActionResult> Get(string title)
    {
        var category = await context.Categories.FirstOrDefaultAsync(c => c.Title == title);
        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Category category)
    {
        context.Add(category);
        await context.SaveChangesAsync();
        return Ok(category);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(Category categoryData)
    {
        var category = await context.Categories.FindAsync(categoryData.Id);
        if (category == null) return NotFound();
        category.Title = categoryData.Title;
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
