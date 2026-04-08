using FighterTrainer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Interfaces
{
    public interface IPresencaRepository
    {
        Task AdicionarAsync(Presenca presenca);
        Task<List<Presenca>> ListarTodasAsync();
        Task<Presenca?> ListarPorId(long presencaId);
        Task<List<Presenca>> ListarPorTurmaId(long turmaId);
        Task<List<Presenca>> ListarPorAtletaId(long atletaId);
        Task AtualizarAsync(Presenca presenca);
       
    }

}
