using System.ComponentModel.DataAnnotations;

namespace DotnetLabs.ViewModels;

public class CreateCategoryViewModel
{
    [Required]
    public string Title { get; set; }
}
