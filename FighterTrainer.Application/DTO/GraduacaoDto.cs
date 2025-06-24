public class GraduacaoDto
{
    public long Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public int Nivel { get; set; }
    public int Grau { get; set; }
    public long ModalidadeId { get; set; }
    public long FederacaoId { get; set; }
}
