using FighterTrainer.Domain.Entities;
using FighterTrainer.Domain.Enums;
using System.ComponentModel.DataAnnotations;

public class FichaTreinoDto
{
    public long Id { get; set; }
    public long AtletaId { get; set; }
    public long UsuarioModalidadeId { get; set; }
    public NivelTreino Nivel { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }
    public long TurmaId { get; set; }
}

