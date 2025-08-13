using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Entities;

public class Graduacao
{
    public long Id { get; set; }
    public long ModalidadeId { get; set; }
    public string Descricao { get; set; }
    public int Nivel {  get; set; }
    public int? Grau { get; set; }
    public long FederacaoId { get; set; }
    public Federacao Federacao { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

    //Exemplo
    //ModalidadeId - 1 (Jiu jitsu)
    //Descricao - Faixa Branca
    //Nivel - 1 (Ordenação principal utilizada para graduação exemplo se branca nivel 1 logo azul = nivel 2 quando se trata de JiuJitsu)
    //Grau - 0 (Se tiver/quantidade) exemplo tambem branca Grau 4
    //Federação para casos em que as faixas níveis e Graus sejam diferentes.



    protected Graduacao() { }
    public Graduacao(long modalidadeId, string descricao, int nivel, int? grau, long federacaoId)
    {
        ModalidadeId = modalidadeId;
        Descricao = descricao;
        Nivel = nivel;
        Grau = grau;
        FederacaoId = federacaoId;
    }

    public void Atualizar(string descricao, int nivel, int grau, long modalidadeId, long federacaoId)
    {
        Descricao = descricao;
        Nivel = nivel;
        Grau = grau;
        ModalidadeId = modalidadeId;
        FederacaoId = federacaoId;
    }

}
