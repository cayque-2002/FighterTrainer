using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FighterTrainer.Domain.Enums;

namespace FighterTrainer.Domain.Entities;

public class FichaTreino
{
    public long Id { get; private set; }
    public long AtletaId { get; private set; }
    public Atleta Atleta { get; private set; }
    public long UsuarioModalidadeId { get; private set; }
    public UsuarioModalidade UsuarioModalidade { get; private set; }
    public NivelTreino Nivel { get; private set; }
    public string Descricao { get; private set; } = string.Empty;
    public DateTime DataCriacao { get; private set; }

    protected FichaTreino() { }

    public FichaTreino(long atletaId, long modalidade, NivelTreino nivel, string descricao)
    {
        AtletaId = atletaId;
        UsuarioModalidadeId = modalidade;
        Nivel = nivel;
        Descricao = descricao;
        DataCriacao = DateTime.UtcNow;
    }
}

