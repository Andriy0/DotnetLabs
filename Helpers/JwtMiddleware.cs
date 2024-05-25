using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace DotnetLabs.Helpers;

public class JwtMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null) await AttachUserToContext(context, token);

        await next(context);
    }
    
    private static Task AttachUserToContext(HttpContext context, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                ValidateIssuer = true,
                ValidIssuer = AuthOptions.Issuer,
                ValidateAudience = true,
                ValidAudience = AuthOptions.Audience,
                // set clock skew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userEmail = jwtToken.Claims.First(x => x.Type == ClaimTypes.Name).Value;

            //Attach user to context on successful JWT validation
            context.Items["UserEmail"] = userEmail;
            context.Items["UserAuthorized"] = "authorized";
        }
        catch
        {
            // Do nothing if JWT validation fails
            // user is not attached to context so the request won't have access to secure routes
        }

        return Task.CompletedTask;
    }
}
