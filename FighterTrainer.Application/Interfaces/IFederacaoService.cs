using FighterTrainer.Domain.Entities;

namespace FighterTrainer.Application.Interfaces;

public interface IFederacaoService
{
    Task<List<FederacaoDto>> ListarTodasAsync();
    Task<IEnumerable<FederacaoDto>> ListarPorId(long federacaoId);
    Task<FederacaoDto> CriarAsync(FederacaoDto dto);
    Task AtualizarAsync(FederacaoDto dto);
    Task<bool> RemoverAsync(long id);

}
