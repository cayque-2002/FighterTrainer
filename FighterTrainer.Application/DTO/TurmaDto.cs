using FighterTrainer.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class TurmaDto
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Descrição é obrigatória.")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "Unidade é obrigatória.")]
    public long UnidadeId { get; set; }

    [Required(ErrorMessage = "Horario Inicio é obrigatório.")]
    public DateTime HoraInicioAula { get; set; }

    [Required(ErrorMessage = "Horario Fim é obrigatório.")]
    public DateTime HoraFimAula { get; set; }

    [Required(ErrorMessage = "Treinador Responsável é obrigatório.")]
    public long TreinadorResponsavelId { get; set; }

    public DateTime DataCriacao { get; set; }
    public bool Ativo { get; set; }
    public int LimiteAlunos { get; set; }

}

