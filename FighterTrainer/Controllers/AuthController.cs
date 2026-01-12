using Application.DTOs;
using FighterTrainer.Domain.Entities;
using FighterTrainer.Infrastructure.Context;
using FighterTrainer.Application.Interfaces;
using FighterTrainer.Application.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly IUsuarioService _usuarioService;

    public AuthController(AppDbContext context, ITokenService tokenService, IUsuarioService usuarioService)
    {
        _context = context;
        _tokenService = tokenService;
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
    //[Authorize(Roles = "Treinador,Administrador")]
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
