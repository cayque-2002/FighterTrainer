using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class LoginDto
{
    [Required(ErrorMessage ="E-mail é obrigatório.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Senha é obrigatória.")]
    public string Senha { get; set; } = string.Empty;
}
