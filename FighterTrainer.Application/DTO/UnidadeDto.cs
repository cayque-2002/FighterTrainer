using System.ComponentModel.DataAnnotations;

public class UnidadeDto
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Descrição é obrigatória.")]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "Cidade é obrigatória.")]
    public long CidadeId { get; set; }
    public DateTime DataCriacao { get; set; }
    public bool Ativo { get; set; }

    public void Inativar() => Ativo = false;

}
