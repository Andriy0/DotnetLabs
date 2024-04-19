using AutoMapper;
using DotnetLabs.Data.Repositories;
using DotnetLabs.Models;
using DotnetLabs.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotnetLabs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(IMapper mapper, CategoryRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<CategoryViewModel>> Get()
    {
        var categories = await repository.GetAll();
        
        return mapper.Map<IEnumerable<CategoryViewModel>>(categories);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await repository.Get(id);
        if (category == null) return NotFound();
        
        return Ok(mapper.Map<CategoryViewModel>(category));
    }
    
    [HttpGet("{title}")]
    public async Task<IActionResult> Get(string title)
    {
        var category = await repository.GetByTitle(title);
        if (category == null) return NotFound();
        
        return Ok(mapper.Map<CategoryViewModel>(category));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateCategoryViewModel categoryVm)
    {
        var category = mapper.Map<Category>(categoryVm);
        await repository.Add(category);
        
        return Ok(mapper.Map<CategoryViewModel>(category));
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, UpdateCategoryViewModel categoryVm)
    {
        var category = mapper.Map<Category>(categoryVm);
        if (id != category.Id) { return BadRequest(); }
        
        await repository.Update(category);
        return Ok(mapper.Map<CategoryViewModel>(category));
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await repository.Delete(id);
        if (category == null) { return NotFound(); }
        
        return Ok(mapper.Map<CategoryViewModel>(category));
    }
}
