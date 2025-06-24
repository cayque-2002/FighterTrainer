using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Entities;

public class Atleta
{
    public long Id { get; private set; }
    public long UsuarioId { get; private set; }

    // Dados do atleta, como peso, faixa, etc (expansível depois)

    protected Atleta() { }
    public Atleta(long usuarioId)
    {
        UsuarioId = usuarioId;
    }
}
