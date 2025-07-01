using FighterTrainer.Domain.Entities;

namespace FighterTrainer.Application.Interfaces;

public interface IModalidadeService
{
    Task<List<ModalidadeDto>> ListarTodasAsync();
    Task<ModalidadeDto> CriarAsync(ModalidadeDto dto);
    Task AtualizarAsync(ModalidadeDto dto);
}
