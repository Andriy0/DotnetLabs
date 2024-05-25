using DotnetLabs.Models;
using MediatR;

namespace DotnetLabs.Services.Login;

public class LoginCommand : IRequest<string>
{
    public User User { get; set; }
}
