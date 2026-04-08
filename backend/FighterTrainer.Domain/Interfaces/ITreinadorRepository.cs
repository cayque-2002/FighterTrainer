using FighterTrainer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Interfaces
{
    public interface ITreinadorRepository
    {
        //Task AdicionarAsync(Treinador treinador);
        Task<List<Treinador>> ListarTodasAsync();
        Task<Treinador?> ListarPorId(long id);
        //Task AtualizarAsync(Treinador treinador);
       
    }

}
