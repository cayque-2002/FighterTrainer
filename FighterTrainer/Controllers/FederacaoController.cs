using FighterTrainer.Application.Interfaces;
using FighterTrainer.Application.Services;
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

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(long id, [FromBody] FederacaoDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID da rota e do corpo não coincidem");

        try
        {
            await _federacaoService.AtualizarAsync(dto);
            return Ok("Federação atualizada com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var resultado = await _federacaoService.RemoverAsync(id);
        if (!resultado)
            return NotFound("Federação não encontrada.");

        return NoContent(); 
    }

}
