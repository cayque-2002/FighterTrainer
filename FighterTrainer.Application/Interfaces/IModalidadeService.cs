using FighterTrainer.Domain.Entities;

namespace FighterTrainer.Application.Interfaces;

public interface IModalidadeService
{
    Task<List<ModalidadeDto>> ListarTodasAsync();
    Task<ModalidadeDto> ListarPorId(long modalidadeId);
    Task<ModalidadeDto> CriarAsync(ModalidadeDto dto);
    Task AtualizarAsync(ModalidadeDto dto);
    Task<bool> RemoverAsync(long id);
}
