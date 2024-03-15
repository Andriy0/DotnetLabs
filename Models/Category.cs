using System.ComponentModel.DataAnnotations;

namespace DotnetLabs.Models;

public class Category
{
    public long Id { get; init; }
    
    [MaxLength(100)]
    public string Title { get; set; }
}
