using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterTrainer.Application.Services;
using FighterTrainer.Domain.Entities;

namespace FighterTrainer.Application.Interfaces
{
    public interface IFichaTreinoService
    {
        Task<FichaTreinoDto> AdicionarAsync(FichaTreinoDto fichaTreino);
        Task<List<FichaTreinoDto>> ListarTodasAsync();
        Task<FichaTreinoDto> ListarPorId(long fichaTreinoId);
        Task AtualizarAsync(FichaTreinoDto dto);
        Task<List<FichaTreinoDto>> ListarAlunosPorTurmaAsync(long turmaId);
        Task<List<FichaTreinoDto>> ListarTreinosPorAtleta(long atletaId);

    }

}
