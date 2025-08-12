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
    public long Id { get;  set; }

    [Required(ErrorMessage = "Atleta é obrigatório.")]
    public long AtletaId { get;  set; }
    public Atleta Atleta { get;  set; }

    [Required(ErrorMessage = "Modalidade é obrigatória.")]
    public long UsuarioModalidadeId { get;  set; }
    public UsuarioModalidade UsuarioModalidade { get;  set; }

    [Required(ErrorMessage = "Nivel é obrigatório.")]
    public NivelTreino Nivel { get;  set; }
    public string Descricao { get;  set; } = string.Empty;
    public DateTime DataCriacao { get;  set; }
    public long TurmaId {  get; set; }
    public Turma Turma { get; set; }   

    public FichaTreino(long atletaId, long modalidade, NivelTreino nivel, string descricao, long turmaId)
    {
        AtletaId = atletaId;
        UsuarioModalidadeId = modalidade;
        Nivel = nivel;
        Descricao = descricao;
        DataCriacao = DateTime.UtcNow;
        TurmaId = turmaId;
    }
}

