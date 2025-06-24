using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Entities;

public class Graduacao
{
    public long Id { get; private set; }
    public long ModalidadeId { get; private set; }
    public string Descricao { get; private set; }
    public int Nivel {  get; private set; }
    public int? Grau { get; private set; }
    public long FederacaoId { get; private set; }
    public Federacao Federacao { get; private set; }

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
}
