using FighterTrainer.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class TreinadorDto
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Usuario é obrigatório.")]
    public long UsuarioId { get; set; }
}

