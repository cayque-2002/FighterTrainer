using FighterTrainer.Domain.Entities;

namespace FighterTrainer.Domain.Interfaces;

public interface IUsuarioModalidadeRepository
{
    Task AdicionarAsync(UsuarioModalidade usuarioModalidade);
    Task<List<UsuarioModalidade>> ObterPorUsuarioIdAsync(long usuarioId);
}
