using Application.DTOs;
using FighterTrainer.Domain.Entities;
using FighterTrainer.Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using FighterTrainer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FighterTrainer.Application.Services;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly TokenService _tokenService;
    private readonly UsuarioService _usuarioService;

    public AuthController(AppDbContext context, TokenService tokenService, UsuarioService usuarioService)
    {
        _context = context;
        _tokenService = tokenService;
        _usuarioService = usuarioService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto dto)
    {
        var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == dto.Email);
        if (usuario == null || !usuario.VerificarSenha(dto.Senha))
            return Unauthorized("Credenciais inválidas");

        var token = _tokenService.GerarToken(usuario);

        return Ok(new { token });
    }

    [HttpPost("register")]
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
