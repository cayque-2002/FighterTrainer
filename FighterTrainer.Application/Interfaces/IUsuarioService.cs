using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterTrainer.Application.Services;
using FighterTrainer.Domain.Entities;

namespace FighterTrainer.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDto>> ListarTodosAsync();
        Task<UsuarioDto> RegistrarUsuarioAsync(CreateUsuarioDto dto);
        Task AtualizarAsync(UsuarioDto dto);
        Task<bool> RemoverAsync(long id);

    }

}
