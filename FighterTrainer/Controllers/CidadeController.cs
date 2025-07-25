using FighterTrainer.Application.Interfaces;
using FighterTrainer.Application.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CidadeController : ControllerBase
{
    private readonly ICidadeService _cidadeService;

    public CidadeController(ICidadeService cidadeService)
    {
        _cidadeService = cidadeService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var lista = await _cidadeService.ListarTodasAsync();
        return Ok(lista);
    }

    [HttpGet("{graduacaoId}")]
    public async Task<IActionResult> GetPorId(long graduacaoId)
    {
        var lista = await _cidadeService.ListarPorId(graduacaoId);
        return Ok(lista);
    }

}
