using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterTrainer.Application.Services;

namespace FighterTrainer.Application.Interfaces
{
    public interface IUsuarioService
    {

       Task<UsuarioDto> RegistrarUsuarioAsync(CreateUsuarioDto dto);
    }

}
