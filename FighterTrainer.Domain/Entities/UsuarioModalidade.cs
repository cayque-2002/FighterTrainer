using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Entities;

public class UsuarioModalidade
{
    public long Id { get; set; }
    public long UsuarioId { get; set; }
    public long ModalidadeId { get; set; }
    public long GraduacaoId { get; set; }
    public DateTime DataInicio { get; set; } = DateTime.Now;
    public bool Ativo { get; set; }


    // Navegações
    public Usuarios Usuario { get; set; }
    public Modalidade Modalidade { get; set; }
    public Graduacao Graduacao { get; set; }

    public UsuarioModalidade(long usuarioId, long modalidadeId, long graduacaoId, DateTime dataInicio, bool ativo)
    {
        UsuarioId = usuarioId;
        ModalidadeId = modalidadeId;
        GraduacaoId = graduacaoId;
        DataInicio = dataInicio;
        Ativo = ativo;

    }

    public void Inativar() => Ativo = false;

    public void Ativar() => Ativo = true;

}

