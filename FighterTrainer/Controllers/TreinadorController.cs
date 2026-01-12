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


public class TreinadorController : ControllerBase
{

    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly TreinadorService _treinadorService;
    private readonly ITreinadorService _iTreinadorService;

    public TreinadorController(AppDbContext context, ITokenService tokenService, TreinadorService treinadorService, ITreinadorService iTreinadorService)
    {
        _context = context;
        _tokenService = tokenService;
        _treinadorService = treinadorService;
        _iTreinadorService = iTreinadorService;
    }


    //[HttpPost]
    //public async Task<IActionResult> Post([FromBody] TreinadorDto dto)
    //{
    //    var nova = await _iTreinadorService.AdicionarAsync(dto);
    //    return Ok(nova);
    //}

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var usuarios = await _iTreinadorService.ListarTodasAsync();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPorId(long id)
    {
        var lista = await _iTreinadorService.ListarPorId(id);
        return Ok(lista);
    }

    //[HttpPut("atualizar/{id}")]
    //public async Task<IActionResult> Atualizar(long id, [FromBody] TreinadorDto dto)
    //{
    //    if (id != dto.Id)
    //    {
    //        return BadRequest("ID da URL e do corpo não coincidem.");
    //    }

    //    try
    //    {
    //        await _iTreinadorService.AtualizarAsync(dto);
    //        return Ok("Atleta atualizado com sucesso.");
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(new { erro = ex.Message });
    //    }
    //}

}

