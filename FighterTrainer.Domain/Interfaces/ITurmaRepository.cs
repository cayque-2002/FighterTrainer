using FighterTrainer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Interfaces
{
    public interface ITurmaRepository
    {

        Task AddAsync(Turma turma);
        Task<List<Turma>> ListarTodasAsync();
        Task<Turma?> ListarPorId(long turmaId);
        Task AdicionarAsync(Turma turma);
        Task AtualizarAsync(Turma turma);
        Task<bool> RemoverAsync(long id);
        Task InativarAsync(long id);


    }

}
