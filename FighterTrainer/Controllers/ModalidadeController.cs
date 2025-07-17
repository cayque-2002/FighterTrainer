using FighterTrainer.Application.Interfaces;
using FighterTrainer.Application.Services;
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

    [HttpGet("{modalidadeId}")]
    public async Task<IActionResult> GetPorId(long modalidadeId)
    {
        var lista = await _modalidadeService.ListarPorId(modalidadeId);
        return Ok(lista);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ModalidadeDto dto)
    {
        var nova = await _modalidadeService.CriarAsync(dto);
        return Ok(nova);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(long id, [FromBody] ModalidadeDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID da rota e do corpo não coincidem");

        try
        {
            await _modalidadeService.AtualizarAsync(dto);
            return Ok("Graduação atualizada com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var resultado = await _modalidadeService.RemoverAsync(id);
        if (!resultado)
            return NotFound("Modalidade não encontrada.");

        return NoContent(); 
    }
}
