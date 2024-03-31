using DotnetLabs.Models;

namespace DotnetLabs.ViewModels;

public class ProductViewModel
{
    public long Id { get; init; }
    public string Title { get; init; }
    public Category Category { get; init; }
}
