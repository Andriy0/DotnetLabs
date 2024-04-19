using System.ComponentModel.DataAnnotations;

namespace DotnetLabs.ViewModels;

public class UpdateCategoryViewModel
{
    [Required]
    public long Id { get; init; }
    
    [Required]
    public string Title { get; set; }
}
