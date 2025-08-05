using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Entities;

public class Turma
{
    public long Id { get; private set; }

    [Required(ErrorMessage = "Descrição é obrigatória.")]
    public string Descricao { get; private set; }

    [Required(ErrorMessage = "Unidade é obrigatória.")]
    public long UnidadeId { get; private set; }
    public Unidade Unidade { get; private set; }

    [Required(ErrorMessage = "Horario Inicio é obrigatório.")]
    public DateTime HoraInicioAula {  get; private set; }

    [Required(ErrorMessage = "Horario Fim é obrigatório.")]
    public DateTime HoraFimAula {  get; private set; }

    [Required(ErrorMessage = "Treinador Responsável é obrigatório.")]
    public long TreinadorResponsavelId {  get; private set; }
    public Treinador Treinador { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public bool Ativo {  get; private set; }

    public Turma(long unidadeId, string descricao, DateTime horaInicioAula, DateTime horaFimAula, long treinadorResponsavelId, DateTime dataCriacao, bool ativo)
    {
        UnidadeId = unidadeId;
        Descricao = descricao;
        HoraInicioAula = horaInicioAula;
        HoraFimAula = horaFimAula;
        TreinadorResponsavelId = treinadorResponsavelId;
        DataCriacao = dataCriacao;
        Ativo = ativo;
    }

    public void Inativar() => Ativo = false;
}
