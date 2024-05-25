using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DotnetLabs.Models;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace DotnetLabs.Services.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly List<User> _users =
    [
        new User("tom@gmail.com", "12345"),
        new User("bob@gmail.com", "55555")
    ];

    public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = _users.FirstOrDefault(p => p.Email == request.User.Email && p.Password == request.User.Password);

        if (user is null)
        {
            return Task.FromResult((string)null);
        }

        var claims = new List<Claim> { new(ClaimTypes.Name, user.Email) };

        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return Task.FromResult(encodedJwt);
    }
}
