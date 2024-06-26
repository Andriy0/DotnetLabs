using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotnetLabs.Models;

public class Category
{
    public long Id { get; init; }
    
    [MaxLength(100)]
    public string Title { get; set; }
    
    [JsonIgnore]
    public ICollection<Product> Products { get; set; }
}
