using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Entities;

public class Treinador
{
    public long Id { get; private set; }

    [Required(ErrorMessage = "Usuario é obrigatório.")]
    public long UsuarioId { get; private set; }

    protected Treinador() { }
    public Treinador(long usuarioId)
    {
        UsuarioId = usuarioId;
       
    }
}

