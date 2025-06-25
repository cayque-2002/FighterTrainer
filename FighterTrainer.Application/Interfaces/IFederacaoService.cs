using FighterTrainer.Domain.Entities;

namespace FighterTrainer.Application.Interfaces;

public interface IFederacaoService
{
    Task<List<FederacaoDto>> ListarTodasAsync();
    Task<FederacaoDto> CriarAsync(FederacaoDto dto);
}
