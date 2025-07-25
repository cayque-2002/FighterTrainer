using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterTrainer.Application.Services;
using FighterTrainer.Domain.Entities;

namespace FighterTrainer.Application.Interfaces
{
    public interface IUnidadeService
    {
        Task<List<UnidadeDto>> ListarTodasAsync();
        Task<UnidadeDto> ListarPorId(long usuarioId);
        Task AtualizarAsync(UnidadeDto dto);
        Task<bool> RemoverAsync(long id);
        Task InativarAsync(long id);

    }

}
