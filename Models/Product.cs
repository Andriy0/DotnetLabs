using System.ComponentModel.DataAnnotations;

namespace DotnetLabs.Models;

public class Product
{
    public long Id { get; init; }
    
    [MaxLength(100)]
    public string Title { get; set; }
    
    public long CategoryId { get; set;  }
    
    public Category Category { get; set; }
}
