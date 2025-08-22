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

    [HttpGet("{cidadeId}")]
    public async Task<IActionResult> GetPorId(long cidadeId)
    {
        var lista = await _cidadeService.ListarPorId(cidadeId);
        return Ok(lista);
    }

}
