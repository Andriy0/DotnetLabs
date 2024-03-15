using DotnetLabs.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetLabs.Data;

public class AppDbContext(IConfiguration configuration) : DbContext
{
    //OnConfiguring() method is used to select and configure the data source
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //use this to configure the context
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("AppDatabase"));
    }

    //OnModelCreating() method is used to configure the model using ModelBuilder Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //use this to configure the model
    }

    //Adding Domain Classes as DbSet Properties
    public DbSet<Category> Categories { get; init; }
}
