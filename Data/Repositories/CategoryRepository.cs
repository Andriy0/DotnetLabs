using DotnetLabs.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetLabs.Data.Repositories;

public class CategoryRepository(AppDbContext context) : IRepository<Category>
{
    public async Task<List<Category>> GetAll()
    {
        return await context.Categories.ToListAsync();
    }

    public async Task<Category> Get(int id)
    {
        return await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
    }
    
    public async Task<Category> GetByTitle(string title)
    {
        return await context.Categories.FirstOrDefaultAsync(c => c.Title == title);
    }
    
    public async Task<Category> Add(Category entity)
    {
        context.Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }
    
    public async Task<Category> Update(Category entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return entity;
    }
    
    public async Task<Category> Delete(int id)
    {
        var entity = await Get(id);
        
        if (entity == null) { return entity; }

        context.Categories.Remove(entity);
        await context.SaveChangesAsync();

        return entity;
    }
}
