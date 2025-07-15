using FighterTrainer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> ObterPorEmailAsync(string email);
        Task<Usuario?> ObterPorIdAsync(long id);
        Task<List<Usuario>> ListarTodosAsync();
        Task AdicionarAsync(Usuario usuario);
        Task<bool> EmailJaCadastradoAsync(string email);
        Task AtualizarAsync(Usuario usuario);
        Task<bool> RemoverAsync(long id);
        Task InativarAsync(long id);


    }

}
