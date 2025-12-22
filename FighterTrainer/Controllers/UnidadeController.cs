using FighterTrainer.Application.Interfaces;
using FighterTrainer.Application.Services;
using FighterTrainer.Application.Services.Auth;
using FighterTrainer.Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FighterTrainer.API.Controllers;

[ApiController]
[Route("[controller]")]


public class UnidadeController : ControllerBase
{

    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly UnidadeService _unidadeService;
    private readonly IUnidadeService _iunidadeService;

    public UnidadeController(AppDbContext context, ITokenService tokenService, UnidadeService unidadeService, IUnidadeService iunidadeService)
    {
        _context = context;
        _tokenService = tokenService;
        _unidadeService = unidadeService;
        _iunidadeService = iunidadeService;
    }


    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<IActionResult> Post([FromBody] UnidadeDto dto)
    {
        var nova = await _unidadeService.CriarAsync(dto);
        return Ok(nova);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get()
    {
        var usuarios = await _iunidadeService.ListarTodasAsync();
        return Ok(usuarios);
    }

    [HttpGet("{unidadeId}")]
    [Authorize]
    public async Task<IActionResult> GetPorId(long unidadeId)
    {
        var lista = await _iunidadeService.ListarPorId(unidadeId);
        return Ok(lista);
    }

    [HttpPut("atualizar/{id}")]
    [Authorize(Roles = "Treinador,Administrador")]
    public async Task<IActionResult> Atualizar(long id, [FromBody] UnidadeDto dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("ID da URL e do corpo não coincidem.");
        }

        try
        {
            await _iunidadeService.AtualizarAsync(dto);
            return Ok("Unidade atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpDelete("{id:long}")]
    [Authorize(Roles = "Treinador,Administrador")]
    public async Task<IActionResult> Delete(long id)
    {
        var resultado = await _iunidadeService.RemoverAsync(id);
        if (!resultado)
            return NotFound("Unidade não encontrada.");

        return NoContent(); // ou Ok("Usuário removido com sucesso");
    }

    [HttpPut("Inativar/{id}")]
    public async Task<IActionResult> Inativar(long id)
    {
        
            await _iunidadeService.InativarAsync(id);
            return Ok("Unidade desativada com sucesso");
        
    }





}

