using System.ComponentModel.DataAnnotations;

namespace DotnetLabs.ViewModels;

public class CreateProductViewModel
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public long CategoryId { get; set; }
}
