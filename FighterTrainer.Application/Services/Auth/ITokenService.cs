using FighterTrainer.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FighterTrainer.Application.Services.Auth
{

    public interface ITokenService
    {
        string GenerateToken(Usuarios usuario);

    }


    //public class ITokenService
    //{

    //private readonly IConfiguration _config;

    //public ITokenService(IConfiguration config)
    //{
    //    _config = config;
    //}

    //public string GenerateToken(Usuario usuario)
    //{
    //    var jwtSettings = _config.GetSection("Jwt");

    //    var claims = new[]
    //    {
    //        new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
    //        new Claim("nome", usuario.Nome),
    //        new Claim(ClaimTypes.Role, usuario.TipoUsuario.ToString()) // Aluno / Treinador / Admin
    //    };

    //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
    //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //    var token = new JwtSecurityToken(
    //        issuer: jwtSettings["Issuer"],
    //        audience: jwtSettings["Audience"],
    //        claims: claims,
    //        expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpireMinutes"])),
    //        signingCredentials: creds
    //    );

    //    return new JwtSecurityTokenHandler().WriteToken(token);
    //}
    //}
}
