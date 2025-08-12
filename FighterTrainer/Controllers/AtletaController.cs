using FighterTrainer.Application.Interfaces;
using FighterTrainer.Application.Services;
using FighterTrainer.Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace FighterTrainer.API.Controllers;

[ApiController]
[Route("[controller]")]


public class AtletaController : ControllerBase
{

    private readonly AppDbContext _context;
    private readonly TokenService _tokenService;
    private readonly AtletaService _atletaService;
    private readonly IAtletaService _iatletaService;

    public AtletaController(AppDbContext context, TokenService tokenService, AtletaService atletaService, IAtletaService iatletaService)
    {
        _context = context;
        _tokenService = tokenService;
        _atletaService = atletaService;
        _iatletaService = iatletaService;
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AtletaDto dto)
    {
        var nova = await _iatletaService.AdicionarAsync(dto);
        return Ok(nova);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var usuarios = await _iatletaService.ListarTodasAsync();
        return Ok(usuarios);
    }

    [HttpGet("{atletaId}")]
    public async Task<IActionResult> GetPorId(long atletaId)
    {
        var lista = await _iatletaService.ListarPorId(atletaId);
        return Ok(lista);
    }

    [HttpPut("atualizar/{id}")]
    public async Task<IActionResult> Atualizar(long id, [FromBody] AtletaDto dto)
    {
        if (id != dto.Id)
        {
            return BadRequest("ID da URL e do corpo não coincidem.");
        }

        try
        {
            await _iatletaService.AtualizarAsync(dto);
            return Ok("Atleta atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

}

