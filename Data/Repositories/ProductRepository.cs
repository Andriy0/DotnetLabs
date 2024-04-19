using DotnetLabs.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetLabs.Data.Repositories;

public class ProductRepository(AppDbContext context) : IRepository<Product>
{
    public async Task<List<Product>> GetAll()
    {
        return await context.Products.Include(p => p.Category).ToListAsync();
    }

    public async Task<Product> Get(int id)
    {
        return await context.Products.Include(p => p.Category).FirstOrDefaultAsync(c => c.Id == id);
    }
    
    public async Task<Product> GetByTitle(string title)
    {
        return await context.Products.Include(p => p.Category).FirstOrDefaultAsync(c => c.Title == title);
    }
    
    public async Task<Product> Add(Product entity)
    {
        context.Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }
    
    public async Task<Product> Update(Product entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return entity;
    }
    
    public async Task<Product> Delete(int id)
    {
        var entity = await Get(id);
        
        if (entity == null) { return entity; }

        context.Products.Remove(entity);
        await context.SaveChangesAsync();

        return entity;
    }
}
