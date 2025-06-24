using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Entities;

public class UsuarioModalidade
{
    public long UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public long ModalidadeId { get; set; }
    public Modalidade Modalidade { get; set; }
    public long GraduacaoId { get; set; }
    public Graduacao Graduacao { get; set; }

    public DateTime DataInicio { get; set; }
    public bool Ativo { get; set; }


    protected UsuarioModalidade() { }
    public UsuarioModalidade(long usuarioId, long modalidadeId, long graduacaoId)
    {
        UsuarioId = usuarioId;
        ModalidadeId = modalidadeId;
        GraduacaoId = graduacaoId;
    }
}

