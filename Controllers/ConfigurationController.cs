using Microsoft.AspNetCore.Mvc;

namespace DotnetLabs.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ConfigurationController(IConfiguration configuration) : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> Get()
    {
        var someValue = configuration.GetSection("SomeGroup:SomeKey").Value;
        var anotherValue = configuration.GetSection("SomeGroup:AnotherKey").Value;
        
        return Task.FromResult<IActionResult>(Ok($"SomeKey: {someValue}, AnotherKey: {anotherValue}"));
    }
}
