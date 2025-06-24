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

    [HttpGet("{usuarioId}")]
    public async Task<IActionResult> Get(long usuarioId)
    {
        var lista = await _service.ListarPorUsuario(usuarioId);
        return Ok(lista);
    }
}
