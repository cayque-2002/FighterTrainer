using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Entities;

public class Modalidade
{
    public long Id { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    //Identificacao da modalidade do atleta, exemplo Boxe, BJJ, Karate e etc.

    protected Modalidade() { }
    public Modalidade(string descricao)
    {
        Descricao = descricao;
    }

    public void Atualizar(string descricao)
    {
        Descricao = descricao;

    }
}
