using FighterTrainer.Application.Interfaces;
using FighterTrainer.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsuarioModalidadeController : ControllerBase
{
    private readonly IUsuarioModalidadeService _service;

    public UsuarioModalidadeController(IUsuarioModalidadeService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UsuarioModalidadeDto dto)
    {
        await _service.AdicionarAsync(dto);
        return Ok("Modalidade vinculada com sucesso!");
    }

    [HttpGet("usuario/{usuarioId}")]
    public async Task<IActionResult> Get(long usuarioId)
    {
        var lista = await _service.ListarPorUsuario(usuarioId);
        return Ok(lista);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPorId(long id)
    {
        var lista = await _service.ListarPorId(id);
        return Ok(lista);
    }

    [HttpPut("inativar/{id}")]
    public async Task<IActionResult> Inativar(long id)
    {

        await _service.InativarAsync(id);
        return Ok("Modalidade do usuário desativada com sucesso");

    }

    [HttpPut("ativar/{id}")]
    public async Task<IActionResult> Ativar(long id)
    {

        await _service.AtivarAsync(id);
        return Ok("Modalidade do usuário ativada com sucesso");

    }
}
