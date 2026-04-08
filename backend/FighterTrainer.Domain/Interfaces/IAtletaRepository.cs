using FighterTrainer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Interfaces
{
    public interface IAtletaRepository
    {
        Task AdicionarAsync(Atleta atleta);
        Task<List<Atleta>> ListarTodasAsync();
        Task<Atleta> ListarPorId(long atletaId);
        Task AtualizarAsync(Atleta atleta);
       
    }

}
