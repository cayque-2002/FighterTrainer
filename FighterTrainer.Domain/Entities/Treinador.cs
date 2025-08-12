using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Entities;

public class Treinador
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Usuario é obrigatório.")]
    public long UsuarioId { get; set; }

    protected Treinador() { }
    public Treinador(long usuarioId)
    {
        UsuarioId = usuarioId;
       
    }
}

