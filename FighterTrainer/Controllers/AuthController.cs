using Application.DTOs;
using FighterTrainer.Domain.Entities;
using FighterTrainer.Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using FighterTrainer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FighterTrainer.Application.Services;
using FighterTrainer.Application.Services.Auth;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly FighterTrainer.Application.Services.Auth.TokenService _tokenService;
    private readonly Infrastructure.Services.TokenService _tokenServiceInfra;

    private readonly UsuarioService _usuarioService;

    public AuthController(AppDbContext context, FighterTrainer.Application.Services.Auth.TokenService tokenService,
                          Infrastructure.Services.TokenService tokenServiceInfra, UsuarioService usuarioService)
    {
        _context = context;
        _tokenService = tokenService;
        _tokenServiceInfra = tokenServiceInfra;
        _usuarioService = usuarioService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public IActionResult Login(LoginDto dto)
    {
        var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == dto.Email);
        
        if (usuario == null) 
        {
            return Unauthorized("Credenciais inválidas");
        }

        var validaSenha = usuario.VerificarSenha(dto.Senha);
        if (validaSenha == false) 
        {
            return Unauthorized("Credenciais inválidas");
        }
            

        var token = _tokenService.GenerateToken(usuario);

        return Ok(new { token });
    }

    [HttpPost("register")]
    [Authorize(Roles = "Treinador,Administrador")]
    public async Task<IActionResult> RegisterAsync(CreateUsuarioDto dto)
    {

        try
        {
            var usuario = await _usuarioService.RegistrarUsuarioAsync(dto);
            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

}
