using AutoMapper;
using DotnetLabs.Models;
using DotnetLabs.Services.Categories;
using DotnetLabs.ViewModels;
using DotnetLabs.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotnetLabs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(IMapper mapper, IMediator mediator) 
    : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IEnumerable<CategoryViewModel>> Get()
    {
        var categories = await mediator.Send(new GetAllCategoriesQuery());
        
        return mapper.Map<IEnumerable<CategoryViewModel>>(categories);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await mediator.Send(new GetCategoryQuery { Id = id });
        if (category == null) return NotFound();
        
        return Ok(mapper.Map<CategoryViewModel>(category));
    }
    
    [HttpGet("{title}")]
    public async Task<IActionResult> Get(string title)
    {
        var category = await mediator.Send(new GetCategoryByTitleQuery { Title = title });
        if (category == null) return NotFound();
        
        return Ok(mapper.Map<CategoryViewModel>(category));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateCategoryViewModel categoryVm)
    {
        // var category = mapper.Map<Category>(categoryVm);
        var category = await mediator.Send(new CreateCategoryCommand { Title = categoryVm.Title });
        
        return Ok(mapper.Map<CategoryViewModel>(category));
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, UpdateCategoryViewModel categoryVm)
    {
        // var category = mapper.Map<Category>(categoryVm);
        if (id != categoryVm.Id) { return BadRequest(); }
        
        var category = await mediator.Send(new UpdateCategoryCommand { Category = mapper.Map<Category>(categoryVm) });
        return Ok(mapper.Map<CategoryViewModel>(category));
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await mediator.Send(new DeleteCategoryCommand { Id = id });
        if (category == null) { return NotFound(); }
        
        return Ok(mapper.Map<CategoryViewModel>(category));
    }
}
