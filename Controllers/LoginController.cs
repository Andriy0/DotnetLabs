using DotnetLabs.Models;
using DotnetLabs.Services.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotnetLabs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login(User user)
    {
        var loginCommand = new LoginCommand { User = user };
        var jwtToken = await mediator.Send(loginCommand);
        
        if (jwtToken == null) { return Unauthorized(); }

        return Ok(jwtToken);
    }
} 
