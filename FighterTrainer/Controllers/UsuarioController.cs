using FighterTrainer.Application.Interfaces;
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
    private readonly IUsuarioService _iusuarioService;

    public UsuarioController(AppDbContext context, TokenService tokenService, UsuarioService usuarioService, IUsuarioService iusuarioService)
    {
        _context = context;
        _tokenService = tokenService;
        _usuarioService = usuarioService;
        _iusuarioService = iusuarioService;
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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var usuarios = await _iusuarioService.ListarTodosAsync();
        return Ok(usuarios);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(long id, [FromBody] UsuarioDto dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("ID da URL e do corpo não coincidem.");
        }

        try
        {
            await _iusuarioService.AtualizarAsync(dto);
            return Ok("Usuário atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var resultado = await _usuarioService.RemoverAsync(id);
        if (!resultado)
            return NotFound("Usuário não encontrado.");

        return NoContent(); // ou Ok("Usuário removido com sucesso");
    }





}

