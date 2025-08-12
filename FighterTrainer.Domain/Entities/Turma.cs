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
    public long Id { get; set; }

    [Required(ErrorMessage = "Descrição é obrigatória.")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Unidade é obrigatória.")]
    public long UnidadeId { get; private set; }
    public Unidade Unidade { get; set; }

    [Required(ErrorMessage = "Horario Inicio é obrigatório.")]
    public DateTime HoraInicioAula {  get; set; }

    [Required(ErrorMessage = "Horario Fim é obrigatório.")]
    public DateTime HoraFimAula {  get; set; }

    [Required(ErrorMessage = "Treinador Responsável é obrigatório.")]
    public long TreinadorResponsavelId {  get; set; }
    public Treinador Treinador { get; set; }
    public DateTime DataCriacao { get; set; }
    public bool Ativo {  get; set; }

    [Required(ErrorMessage = "Necessário definir uma quantidade de alunos por Turma.")]
    public int LimiteAlunos { get; set; }

    public Turma(long unidadeId, string descricao, DateTime horaInicioAula, DateTime horaFimAula, long treinadorResponsavelId, DateTime dataCriacao, bool ativo, int limiteAlunos)
    {
        UnidadeId = unidadeId;
        Descricao = descricao;
        HoraInicioAula = horaInicioAula;
        HoraFimAula = horaFimAula;
        TreinadorResponsavelId = treinadorResponsavelId;
        DataCriacao = dataCriacao;
        Ativo = ativo;
        LimiteAlunos = limiteAlunos;
    }

    public void Inativar() => Ativo = false;
}
