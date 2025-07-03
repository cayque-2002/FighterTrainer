using FighterTrainer.Domain.Entities;

namespace FighterTrainer.Application.Interfaces;

public interface IGraduacaoService
{
    Task<List<GraduacaoDto>> ListarTodasAsync();
    Task<GraduacaoDto> CriarAsync(GraduacaoDto dto);
    Task AtualizarAsync(GraduacaoDto dto);
    Task<bool> RemoverAsync(long id);

}
