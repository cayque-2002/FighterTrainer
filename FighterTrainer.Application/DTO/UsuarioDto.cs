using FighterTrainer.Domain.Enums;
using System.ComponentModel.DataAnnotations;

public class UsuarioDto
{
    public long Id { get; set; }

    [Required(ErrorMessage = "É necessário informar o nome do usuário.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "É necessário informar o e-mail do usuário.")]
    [EmailAddress(ErrorMessage ="O e-mail está em formato inválido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O tipo de usuário é obrigatório")]
    public TipoUsuario Tipo { get; set; }

    [Required(ErrorMessage = "É necessário informar a situação do usuário.")]
    public bool Ativo { get; set; }


    public void Inativar() => Ativo = false;
}
