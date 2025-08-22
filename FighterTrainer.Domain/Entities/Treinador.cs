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
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;


    public Usuario Usuario { get; set; }

    public Treinador(long usuarioId)
    {
        UsuarioId = usuarioId;
       
    }
}

