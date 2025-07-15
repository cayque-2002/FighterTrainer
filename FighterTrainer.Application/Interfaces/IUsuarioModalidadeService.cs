using FighterTrainer.Domain.Entities;

namespace FighterTrainer.Application.Interfaces;

public interface IUsuarioModalidadeService
{
    Task AdicionarAsync(UsuarioModalidadeDto dto);
    Task<IEnumerable<UsuarioModalidade>> ListarPorUsuario(long usuarioId);
    Task InativarAsync(long usuarioId, long modalidadeId);

}
