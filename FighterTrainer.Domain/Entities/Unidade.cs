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

    public Unidade(string descricao, long cidadeId, DateTime dataCriacao, bool ativo)
    {

        Descricao = descricao;
        CidadeId = cidadeId;
        DataCriacao = dataCriacao;
        Ativo = ativo;

    }

    public void Inativar() => Ativo = false;

}
