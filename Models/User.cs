using System.ComponentModel.DataAnnotations;

namespace DotnetLabs.Models;

public class User(string email, string password)
{
    [Required]
    public string Email { get; set; } = email;
    
    [Required]
    public string Password { get; set; } = password;
}
