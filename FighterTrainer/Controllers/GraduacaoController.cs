using FighterTrainer.Application.Interfaces;
using FighterTrainer.Application.Services;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<IActionResult> Get()
    {
        var lista = await _graduacaoService.ListarTodasAsync();
        return Ok(lista);
    }

    [HttpGet("{graduacaoId}")]
    public async Task<IActionResult> GetPorId(long graduacaoId)
    {
        var lista = await _graduacaoService.ListarPorId(graduacaoId);
        return Ok(lista);
    }

    [HttpPost]
    [Authorize(Roles = "Treinador,Administrador")]
    public async Task<IActionResult> Post([FromBody] GraduacaoDto dto)
    {
        var nova = await _graduacaoService.CriarAsync(dto);
        return Ok(nova);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Treinador,Administrador")]
    public async Task<IActionResult> Atualizar(long id, [FromBody] GraduacaoDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID da rota e do corpo não coincidem");

        try
        {
            await _graduacaoService.AtualizarAsync(dto);
            return Ok("Graduação atualizada com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpDelete("{id:long}")]
    [Authorize(Roles = "Treinador,Administrador")]
    public async Task<IActionResult> Delete(long id)
    {
        var resultado = await _graduacaoService.RemoverAsync(id);
        if (!resultado)
            return NotFound("Graduação não encontrada.");

        return NoContent(); 
    }


}
