using Microsoft.AspNetCore.Mvc;

namespace DotnetLabs.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ConfigurationController(IConfiguration configuration, ILogger<ConfigurationController> logger) : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> Get()
    {
        var someValue = configuration.GetSection("SomeGroup:SomeKey").Value;
        var anotherValue = configuration.GetSection("SomeGroup:AnotherKey").Value;
        var text = $"SomeKey: {someValue}, AnotherKey: {anotherValue}";
        
        logger.LogDebug(text);
        
        return Task.FromResult<IActionResult>(Ok(text));
    }
}
