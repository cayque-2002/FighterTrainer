using System;
using System.ComponentModel.DataAnnotations;

namespace FighterTrainer.Domain.Entities;

public class Presenca
{
    public long Id { get; set; }

    [Required]
    public long TurmaId { get; set; }
    public Turma Turma { get; set; }

    [Required]
    public long AtletaId { get; set; }
    public Atleta Atleta { get; set; }

    public DateTime DataHoraCadastro { get; set; } = DateTime.UtcNow;

    protected Presenca() { }

    public Presenca(long turmaId, long atletaId)
    {
        TurmaId = turmaId;
        AtletaId = atletaId;
        DataHoraCadastro = DateTime.UtcNow;
    }
}
