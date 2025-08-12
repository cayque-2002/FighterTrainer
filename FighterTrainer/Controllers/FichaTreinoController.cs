using FighterTrainer.Application.Interfaces;
using FighterTrainer.Application.Services;
using FighterTrainer.Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace FighterTrainer.API.Controllers;

[ApiController]
[Route("[controller]")]


public class FichaTreinoController : ControllerBase
{

    private readonly AppDbContext _context;
    private readonly TokenService _tokenService;
    private readonly FichaTreinoService _fichaTreinoService;
    private readonly IFichaTreinoService _iFichaTreinoService;

    public FichaTreinoController(AppDbContext context, TokenService tokenService, FichaTreinoService fichaTreinoService, IFichaTreinoService iFichaTreinoService)
    {
        _context = context;
        _tokenService = tokenService;
        _fichaTreinoService = fichaTreinoService;
        _iFichaTreinoService = iFichaTreinoService;
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FichaTreinoDto dto)
    {
        var nova = await _iFichaTreinoService.AdicionarAsync(dto);
        return Ok(nova);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var usuarios = await _iFichaTreinoService.ListarTodasAsync();
        return Ok(usuarios);
    }

    [HttpGet("{atletaId}")]
    public async Task<IActionResult> GetPorId(long atletaId)
    {
        var lista = await _iFichaTreinoService.ListarPorId(atletaId);
        return Ok(lista);
    }

    [HttpPut("atualizar/{id}")]
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

}

