using FighterTrainer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GraduacaoController : ControllerBase
{
    private readonly IGraduacaoService _graduacaoService;

    public GraduacaoController(IGraduacaoService graduacaoService)
    {
        _graduacaoService = graduacaoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var lista = await _graduacaoService.ListarTodasAsync();
        return Ok(lista);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GraduacaoDto dto)
    {
        var nova = await _graduacaoService.CriarAsync(dto);
        return Ok(nova);
    }
}
