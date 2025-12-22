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


public class FichaTreinoController : ControllerBase
{

    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly FichaTreinoService _fichaTreinoService;
    private readonly IFichaTreinoService _iFichaTreinoService;

    public FichaTreinoController(AppDbContext context, ITokenService tokenService, FichaTreinoService fichaTreinoService, IFichaTreinoService iFichaTreinoService)
    {
        _context = context;
        _tokenService = tokenService;
        _fichaTreinoService = fichaTreinoService;
        _iFichaTreinoService = iFichaTreinoService;
    }


    [HttpPost]
    [Authorize(Roles = "Treinador,Administrador")]
    public async Task<IActionResult> Post([FromBody] FichaTreinoDto dto)
    {
        var nova = await _iFichaTreinoService.AdicionarAsync(dto);
        return Ok(nova);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get()
    {
        var fichasTreino = await _iFichaTreinoService.ListarTodasAsync();
        return Ok(fichasTreino);
    }

    [HttpGet("{fichaTreinoId}")]
    [Authorize]
    public async Task<IActionResult> GetPorId(long fichaTreinoId)
    {
        var lista = await _iFichaTreinoService.ListarPorId(fichaTreinoId);
        return Ok(lista);
    }

    [HttpPut("atualizar/{id}")]
    [Authorize(Roles = "Treinador,Administrador")]
    public async Task<IActionResult> Atualizar(long id, [FromBody] FichaTreinoDto dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("ID da URL e do corpo não coincidem.");
        }

        try
        {
            await _iFichaTreinoService.AtualizarAsync(dto);
            return Ok("Ficha de Treino atualizada com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpGet("turma/{turmaId}")]
    [Authorize]
    public async Task<IActionResult> GetAlunosPorTurma(long turmaId)
    {
        var fichasTreino = await _iFichaTreinoService.ListarAlunosPorTurmaAsync(turmaId);
        return Ok(fichasTreino);
    }

    [HttpGet("atleta/{atletaId}")]
    [Authorize]
    public async Task<IActionResult> GetTreinosPorAtleta(long atletaId)
    {
        var fichasTreino = await _iFichaTreinoService.ListarTreinosPorAtleta(atletaId);
        return Ok(fichasTreino);
    }

}

