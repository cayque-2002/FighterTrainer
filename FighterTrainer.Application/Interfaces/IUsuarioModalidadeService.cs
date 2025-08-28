using FighterTrainer.Domain.Entities;

namespace FighterTrainer.Application.Interfaces;

public interface IUsuarioModalidadeService
{
    Task AdicionarAsync(UsuarioModalidadeDto dto);
    Task<List<UsuarioModalidade>> ListarPorUsuario(long usuarioId);
    Task<UsuarioModalidade> ListarPorId(long id);
    Task InativarAsync(long id);
    Task AtivarAsync(long id);
    Task<UsuarioModalidade> ValidaUsuarioModalidade(long id);
    Task<UsuarioModalidade> ValidaVinculoUsuarioModalidade(long usuarioId, long atletaId);

}
