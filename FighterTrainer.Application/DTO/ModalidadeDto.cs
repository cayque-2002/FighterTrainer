using System.ComponentModel.DataAnnotations;

public class ModalidadeDto
{
    public long Id { get; set; }

    [Required(ErrorMessage ="Descrição é obrigatória.")]
    public string Descricao { get; set; } = string.Empty;
}
