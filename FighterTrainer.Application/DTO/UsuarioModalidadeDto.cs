using System.ComponentModel.DataAnnotations;

public class UsuarioModalidadeDto
{
    [Required(ErrorMessage = "É necessário informar o usuário.")] 
    public long UsuarioId { get; set; }

    [Required(ErrorMessage = "É necessário informar a modalidade.")]
    public long ModalidadeId { get; set; }

    [Required(ErrorMessage = "É necessário informar qual a graduacao do usuario nesta modalidade.")]
    public long GraduacaoId { get; set; }

    [Required(ErrorMessage = "É necessário informar uma data de início.")]
    public DateTime DataInicio { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "É necessário informar a situação do usuário na modalidade.")] 
    public bool Ativo { get; set; }

    public void Inativar() => Ativo = false;
}
