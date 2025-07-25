using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Entities;

public class Unidade
{
    public long Id { get; private set; }

    [Required(ErrorMessage = "Descrição é obrigatória.")]
    public string Descricao { get; private set; }

    [Required(ErrorMessage = "Cidade é obrigatória.")]
    public long CidadeId { get; private set; }
    public Cidade Cidade { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public bool Ativo {  get; private set; }
    protected Unidade() { }
    public Unidade(long unidadeId)
    {
        Id = unidadeId;
    }

    public void Inativar() => Ativo = false;

}
