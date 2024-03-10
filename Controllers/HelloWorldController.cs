using DotnetLabs.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetLabs.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloWorldController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hello, world!";
    }

    [HttpPost]
    public User Post(User user)
    {
        return user;
    }
}
