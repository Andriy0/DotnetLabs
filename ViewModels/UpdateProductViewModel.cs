using System.ComponentModel.DataAnnotations;

namespace DotnetLabs.ViewModels;

public class UpdateProductViewModel
{
    [Required]
    public long Id { get; init; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public long CategoryId { get; set; }
}
