using FighterTrainer.Application.Services;
using FighterTrainer.Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace FighterTrainer.API.Controllers;

[ApiController]
[Route("[controller]")]


public class UsuarioController : ControllerBase
{

    private readonly AppDbContext _context;
    private readonly TokenService _tokenService;
    private readonly UsuarioService _usuarioService;

    public UsuarioController(AppDbContext context, TokenService tokenService, UsuarioService usuarioService)
    {
        _context = context;
        _tokenService = tokenService;
        _usuarioService = usuarioService;
    }


    [HttpPost("vincular-modalidade")]
    public async Task<IActionResult> VincularModalidade([FromBody] long usuarioId, long modalidadeId, long graduacaoId)
    {
        try
        {
            await _usuarioService.VincularUsuarioModalidadeAsync(usuarioId, modalidadeId, graduacaoId);
            return Ok("Vínculo realizado com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }


}

