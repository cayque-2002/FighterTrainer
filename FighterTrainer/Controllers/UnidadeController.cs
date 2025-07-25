using FighterTrainer.Application.Interfaces;
using FighterTrainer.Application.Services;
using FighterTrainer.Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace FighterTrainer.API.Controllers;

[ApiController]
[Route("[controller]")]


public class UnidadeController : ControllerBase
{

    private readonly AppDbContext _context;
    private readonly TokenService _tokenService;
    private readonly UnidadeService _unidadeService;
    private readonly IUnidadeService _iunidadeService;

    public UnidadeController(AppDbContext context, TokenService tokenService, UnidadeService unidadeService, IUnidadeService iunidadeService)
    {
        _context = context;
        _tokenService = tokenService;
        _unidadeService = unidadeService;
        _iunidadeService = iunidadeService;
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var usuarios = await _iunidadeService.ListarTodasAsync();
        return Ok(usuarios);
    }

    [HttpGet("{usuarioId}")]
    public async Task<IActionResult> GetPorId(long usuarioId)
    {
        var lista = await _iunidadeService.ListarPorId(usuarioId);
        return Ok(lista);
    }

    [HttpPut("atualizar/{id}")]
    public async Task<IActionResult> Atualizar(long id, [FromBody] UnidadeDto dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("ID da URL e do corpo não coincidem.");
        }

        try
        {
            await _iunidadeService.AtualizarAsync(dto);
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
        var resultado = await _iunidadeService.RemoverAsync(id);
        if (!resultado)
            return NotFound("Usuário não encontrado.");

        return NoContent(); // ou Ok("Usuário removido com sucesso");
    }

    [HttpPut("Inativar/{id}")]
    public async Task<IActionResult> Inativar(long id)
    {
        
            await _iunidadeService.InativarAsync(id);
            return Ok("usuario desativado com sucesso");
        
    }





}

