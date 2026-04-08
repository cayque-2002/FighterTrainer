using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterTrainer.Application.Services;
using FighterTrainer.Domain.Entities;

namespace FighterTrainer.Application.Interfaces
{
    public interface IPresencaService
    {
        Task<PresencaDto> AdicionarAsync(PresencaDto fichaTreino);
        Task<List<PresencaDto>> ListarTodasAsync();
        Task<PresencaDto> ListarPorId(long presencaId);
        Task<List<PresencaDto>> ListarPresencasPorTurmaAsync(long turmaId);
        Task<List<PresencaDto>> ListarPresencasPorAtletaAsync(long atletaId);
        Task AtualizarAsync(PresencaDto dto);

    }

}
