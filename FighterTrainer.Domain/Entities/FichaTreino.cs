using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FighterTrainer.Domain.Enums;

namespace FighterTrainer.Domain.Entities;

public class FichaTreino
{
    public long Id { get; private set; }

    [Required(ErrorMessage = "Atleta é obrigatório.")]
    public long AtletaId { get; private set; }
    public Atleta Atleta { get; private set; }

    [Required(ErrorMessage = "Modalidade é obrigatória.")]
    public long UsuarioModalidadeId { get; private set; }
    public UsuarioModalidade UsuarioModalidade { get; private set; }

    [Required(ErrorMessage = "Nivel é obrigatório.")]
    public NivelTreino Nivel { get; private set; }
    public string Descricao { get; private set; } = string.Empty;
    public DateTime DataCriacao { get; private set; }

    protected FichaTreino() { }

    public FichaTreino(long atletaId, long modalidade, NivelTreino nivel, string descricao)
    {
        AtletaId = atletaId;
        UsuarioModalidadeId = modalidade;
        Nivel = nivel;
        Descricao = descricao;
        DataCriacao = DateTime.UtcNow;
    }
}

