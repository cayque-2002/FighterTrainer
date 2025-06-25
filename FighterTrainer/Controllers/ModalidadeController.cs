using FighterTrainer.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ModalidadeController : ControllerBase
{
    private readonly IModalidadeService _modalidadeService;

    public ModalidadeController(IModalidadeService modalidadeService)
    {
        _modalidadeService = modalidadeService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var lista = await _modalidadeService.ListarTodasAsync();
        return Ok(lista);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ModalidadeDto dto)
    {
        var nova = await _modalidadeService.CriarAsync(dto);
        return Ok(nova);
    }
}
