using System.ComponentModel.DataAnnotations;

public class FederacaoDto
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Descrição é obrigatória.")]
    public string Descricao { get; set; } = string.Empty;
    
}
