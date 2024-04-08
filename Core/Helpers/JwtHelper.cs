using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Helpers;

public class JwtHelper
{
    private readonly byte[] _jwtSecretKey;
    private readonly RandomService _randomService;

    public JwtHelper(
        IConfiguration configuration,
        RandomService randomService)
    {
        _jwtSecretKey = Encoding.ASCII.GetBytes(configuration["JwtSettings:SecretKey"] ?? throw new Exception("Jwt secret key not found"));
        _randomService = randomService;
    }

    public string GenerateAccessToken(Claim[] claims, TimeSpan expirty)
    {
        var now = DateTime.Now;

        JwtSecurityTokenHandler tokenHandler = new();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = now.Add(expirty),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_jwtSecretKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        return _randomService.GenerateToken(32);
    }
}
