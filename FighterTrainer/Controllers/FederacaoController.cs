using FighterTrainer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FederacaoController : ControllerBase
{
    private readonly IFederacaoService _federacaoService;

    public FederacaoController(IFederacaoService federacaoService)
    {
        _federacaoService = federacaoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var lista = await _federacaoService.ListarTodasAsync();
        return Ok(lista);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FederacaoDto dto)
    {
        var nova = await _federacaoService.CriarAsync(dto);
        return Ok(nova);
    }
}
