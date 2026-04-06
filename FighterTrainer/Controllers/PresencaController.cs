using FighterTrainer.Application.Interfaces;
using FighterTrainer.Application.Services;
using FighterTrainer.Application.Services.Auth;
using FighterTrainer.Domain.Enums;
using FighterTrainer.Domain.Exceptions;
using FighterTrainer.Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FighterTrainer.API.Controllers;

[ApiController]
[Route("[controller]")]


public class PresencaController : ControllerBase
{

    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly PresencaService _presencaService;
    private readonly IPresencaService _iPresencaService;
    private readonly IUsuarioService _iUsuarioService;

    public PresencaController(AppDbContext context, ITokenService tokenService, PresencaService presencaService,
                              IPresencaService iPresencaService, IUsuarioService iUsuarioService)
    {
        _context = context;
        _tokenService = tokenService;
        _presencaService = presencaService;
        _iPresencaService = iPresencaService;
        _iUsuarioService = iUsuarioService;
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PresencaDto dto, long usuarioId)
    {
        
        var usuario = await _iUsuarioService.ListarPorId(usuarioId);

        var isProfessor = usuario.Tipo == TipoUsuario.Treinador || usuario.Tipo == TipoUsuario.Admin;

        var validaHorario = await _presencaService.ValidaPresencaAlunoHorario(dto.TurmaId, DateOnly.FromDateTime(DateTime.Now), isProfessor);

        if (validaHorario)
        {
            var nova = await _iPresencaService.AdicionarAsync(dto);
            return Ok(nova);
        }
        else
        {
            return BadRequest("Não é possível registrar a presença fora do horário permitido.");
        }
        
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var presencas = await _iPresencaService.ListarTodasAsync();
        return Ok(presencas);
    }

    [HttpGet("{presencaId}")]
    public async Task<IActionResult> GetPorId(long fichaTreinoId)
    {
        var lista = await _iPresencaService.ListarPorId(fichaTreinoId);
        return Ok(lista);
    }

    [HttpPut("atualizar/{id}")]
    public async Task<IActionResult> Atualizar(long id, [FromBody] PresencaDto dto)
    {

        var usuario = await _iUsuarioService.ListarPorId(dto.Id);

        if (usuario.Tipo != TipoUsuario.Treinador && usuario.Tipo != TipoUsuario.Admin)
        {
            return Forbid("Apenas treinadores ou administradores podem atualizar presencas de treino.");
        }

        if (id != dto.Id)
        {
            return BadRequest("ID da URL e do corpo não coincidem.");
        }

        try
        {
            await _iPresencaService.AtualizarAsync(dto);
            return Ok("Ficha de Treino atualizada com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpGet("turma/{turmaId}")]
    public async Task<IActionResult> GetPresencasPorTurma(long turmaId)
    {
        var presencas = await _iPresencaService.ListarPresencasPorTurmaAsync(turmaId);
        return Ok(presencas);
    }

    [HttpGet("atleta/{atletaId}")]
    public async Task<IActionResult> GetPresencasPorAtleta(long atletaId)
    {
        var presencas = await _iPresencaService.ListarPresencasPorAtletaAsync(atletaId);
        return Ok(presencas);
    }

}

