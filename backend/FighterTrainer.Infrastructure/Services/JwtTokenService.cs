using FighterTrainer.Domain;
using FighterTrainer.Domain.Entities;
using Microsoft.Extensions.Configuration;
using FighterTrainer.Application.Services.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services;


public class JwtTokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Usuarios usuario)
    {
        var jwtSettings = _configuration.GetSection("Jwt");

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
            new Claim(ClaimTypes.Name, usuario.Email),
            new Claim(ClaimTypes.Role, usuario.TipoUsuario.ToString())
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings["Key"]!)
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                Convert.ToDouble(jwtSettings["ExpireMinutes"])
            ),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}


//public class JwtTokenService 
//{
//    private readonly IConfiguration _configuration;

//    public JwtTokenService(IConfiguration configuration)
//    {
//        _configuration = configuration;
//    }

//    public string GerarToken(Usuario usuario)
//    {
//        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);

//        var claims = new[]
//        {
//            new Claim(ClaimTypes.Name, usuario.Email),
//            new Claim("id", usuario.Id.ToString()),
//            new Claim(ClaimTypes.Role, usuario.TipoUsuario.ToString())
//        };


//        var tokenDescriptor = new SecurityTokenDescriptor
//        {
//            Subject = new ClaimsIdentity(claims),
//            Expires = DateTime.UtcNow.AddHours(2),
//            SigningCredentials = new SigningCredentials(
//                new SymmetricSecurityKey(key),
//                SecurityAlgorithms.HmacSha256Signature
//            )
//        };

//        var tokenHandler = new JwtSecurityTokenHandler();
//        return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
//    }
//}
