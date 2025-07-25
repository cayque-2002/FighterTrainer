using FighterTrainer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Interfaces
{
    public interface IUnidadeRepository
    {
        Task<List<Unidade>> ListarTodasAsync();

        Task<Unidade?> ListarPorId(long unidadeId);
        Task AdicionarAsync(Unidade unidade);
        Task AtualizarAsync(Unidade unidade);
        Task<bool> RemoverAsync(long id);
        Task InativarAsync(long id);


    }

}
