using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Entities;

public class Cidade
{
    public long Id { get; private set; }
    public string Nome { get; private set; }
    public string UF { get; private set; }

    protected Cidade() { }
    public Cidade(long cidadeId)
    {
        Id = cidadeId;
    }
}
