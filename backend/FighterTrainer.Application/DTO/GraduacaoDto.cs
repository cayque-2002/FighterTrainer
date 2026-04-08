using System.ComponentModel.DataAnnotations;

public class GraduacaoDto
{
    public long Id { get; set; }

    [Required(ErrorMessage ="Descrição é obrigatória.")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "Nivel é obrigatório.")]
    public int Nivel { get; set; }

    [Required(ErrorMessage = "Grau é obrigatório.")]
    public int Grau { get; set; }

    [Required(ErrorMessage = "Modalidade é obrigatória.")]
    public long ModalidadeId { get; set; }

    [Required(ErrorMessage = "Federacao é obrigatória.")]
    public long FederacaoId { get; set; }
}
