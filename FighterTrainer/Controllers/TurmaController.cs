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


public class TurmaController : ControllerBase
{

    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly TurmaService _turmaService;
    private readonly ITurmaService _iturmaService;

    public TurmaController(AppDbContext context, ITokenService tokenService,TurmaService turmaService, ITurmaService iturmaService)
    {
        _context = context;
        _tokenService = tokenService;
        _turmaService = turmaService;
        _iturmaService = iturmaService;
    }


    [HttpPost]
    [Authorize(Roles = "Treinador,Administrador")]
    public async Task<IActionResult> Post([FromBody] TurmaDto dto)
    {
        var nova = await _turmaService.CriarAsync(dto);
        return Ok(nova);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get()
    {
        var usuarios = await _iturmaService.ListarTodasAsync();
        return Ok(usuarios);
    }

    [HttpGet("{turmaId}")]
    [Authorize]
    public async Task<IActionResult> GetPorId(long turmaId)
    {
        var lista = await _iturmaService.ListarPorId(turmaId);
        return Ok(lista);
    }

    [HttpPut("atualizar/{id}")]
    [Authorize(Roles = "Treinador,Administrador")]
    public async Task<IActionResult> Atualizar(long id, [FromBody] TurmaDto dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("ID da URL e do corpo não coincidem.");
        }

        try
        {
            await _iturmaService.AtualizarAsync(dto);
            return Ok("Turma atualizada com sucesso.");
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
        var resultado = await _iturmaService.RemoverAsync(id);
        if (!resultado)
            return NotFound("Turma não encontrada.");

        return NoContent(); // ou Ok("Usuário removido com sucesso");
    }

    [HttpPut("Inativar/{id}")]
    [Authorize(Roles = "Treinador,Administrador")]
    public async Task<IActionResult> Inativar(long id)
    {
        
            await _iturmaService.InativarAsync(id);
            return Ok("Turma desativada com sucesso");
        
    }





}

