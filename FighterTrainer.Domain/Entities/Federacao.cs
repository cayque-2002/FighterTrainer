using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Entities;

public class Federacao
{
    public long Id { get; private set; }
    public string Descricao { get; private set; }

    //Por enquanto só nome da federação

    protected Federacao() { }
    public Federacao(string descricao)
    {
        Descricao = descricao;
    }
}
