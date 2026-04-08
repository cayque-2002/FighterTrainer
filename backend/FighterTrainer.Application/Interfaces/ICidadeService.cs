using FighterTrainer.Domain.Entities;

namespace FighterTrainer.Application.Interfaces;

public interface ICidadeService
{
    Task<List<CidadeDto>> ListarTodasAsync();
    Task<CidadeDto> ListarPorId(long cidadeId);
    Task<Cidade> ValidaCidade(long cidadeId);

}
