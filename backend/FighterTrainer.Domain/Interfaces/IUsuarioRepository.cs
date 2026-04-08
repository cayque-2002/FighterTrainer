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
        Task<Usuarios?> ObterPorEmailAsync(string email);
        Task<Usuarios?> ObterPorIdAsync(long id);
        Task<List<Usuarios>> ListarTodosAsync();
        Task AdicionarAsync(Usuarios usuario);
        Task<bool> EmailJaCadastradoAsync(string email);
        Task AtualizarAsync(Usuarios usuario);
        Task<bool> RemoverAsync(long id);
        Task InativarAsync(long id);
        Task CriarAtleta(Atleta atleta);
        Task CriarTreinador(Treinador treinador);


    }

}
