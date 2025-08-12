using FighterTrainer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Interfaces
{
    public interface IFichaTreinoRepository
    {
        Task AdicionarAsync(FichaTreino atleta);
        Task<List<FichaTreino>> ListarTodasAsync();
        Task<FichaTreino?> ListarPorId(long atletaId);
        Task AtualizarAsync(FichaTreino atleta);
       
    }

}
