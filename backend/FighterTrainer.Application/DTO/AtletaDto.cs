using FighterTrainer.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class AtletaDto
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Usuario é obrigatório.")]
    public long UsuarioId { get; set; }
    public decimal Peso { get; set; }
    public int Altura { get; set; }
    public string Apelido { get; set; } = string.Empty;
    public int Resistencia { get; set; }
    public int Agilidade { get; set; }
    public int Solo { get; set; }
    public int Wrestling { get; set; }
    public int FocoMental { get; set; }
    public int Defesa { get; set; }
    public int LutaEmPe { get; set; }

}

