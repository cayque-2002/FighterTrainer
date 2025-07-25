using System.ComponentModel.DataAnnotations;

public class CidadeDto
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    [Length(2,2, ErrorMessage = "UF deve ser dois caracteres")]
    public string Estado { get; set; } = string.Empty;

}
