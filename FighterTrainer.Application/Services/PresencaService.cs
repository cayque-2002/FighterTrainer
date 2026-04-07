using FighterTrainer.Application.Interfaces;
using FighterTrainer.Domain.Entities;
using FighterTrainer.Domain.Enums;
using FighterTrainer.Domain.Exceptions;
using FighterTrainer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Application.Services
{
    public class PresencaService : IPresencaService
    {
        private readonly IPresencaRepository _PresencaRepository;
        private readonly IFichaTreinoRepository _FichaTreinoRepository;
        private readonly ITurmaRepository _TurmaRepository;
        private readonly IAtletaRepository _AtletaRepository;
        private readonly IUsuarioModalidadeRepository _UsuarioModalidadeRepository;
        private readonly IAtletaService _AtletaService;
        private readonly IUsuarioModalidadeService _UsuarioModalidadeService;
        private readonly IUsuarioService _UsuarioService;
        private readonly ITurmaService _TurmaService;


        public PresencaService(
        IPresencaRepository presencaRepository,
        IFichaTreinoRepository fichaTreinoRepository,
        ITurmaRepository turmaRepository, IAtletaRepository atletaRepository, 
        IUsuarioModalidadeRepository usuarioModalidadeRepository,
        IUsuarioService usuarioService,
        IAtletaService atletaService, IUsuarioModalidadeService usuarioModalidadeService, 
        ITurmaService turmaService )
        {
            _PresencaRepository = presencaRepository;
            _FichaTreinoRepository = fichaTreinoRepository;
            _TurmaRepository = turmaRepository;
            _AtletaRepository = atletaRepository;
            _UsuarioModalidadeRepository = usuarioModalidadeRepository;
            _AtletaService = atletaService;
            _UsuarioModalidadeService = usuarioModalidadeService;
            _UsuarioService = usuarioService;
            _TurmaService = turmaService;
        }

        public async Task<PresencaDto> AdicionarAsync(PresencaDto dto)
        {
            //valida se a Turma existe 
            var turma = await _TurmaService.ValidaTurma(dto.TurmaId);

            //valida se o atleta existe
            var atleta = await _AtletaService.ValidaAtleta( dto.AtletaId);

            var usuarioModalidadeAtleta = await _UsuarioModalidadeRepository.ObterPorUsuarioIdAsync(atleta.UsuarioId);

            var usuarioModalidade = usuarioModalidadeAtleta.Where(x => x.ModalidadeId == turma.ModalidadeId).FirstOrDefault();
             
            await _UsuarioModalidadeService.ValidaVinculoUsuarioAtletaModalidade(usuarioModalidade.Id, atleta.Id);

            var presenca = new Presenca(dto.TurmaId, dto.AtletaId, dto.DataHoraCadastro);
            await _PresencaRepository.AdicionarAsync(presenca);

            return new PresencaDto
            {
                TurmaId = dto.TurmaId,
                AtletaId = dto.AtletaId,
                DataHoraCadastro = presenca.DataHoraCadastro
            };

        }

        public async Task<PresencaDto> ListarPorId(long presencaId)
        {
            var presenca = await _PresencaRepository.ListarPorId(presencaId);

            if (presenca == null)
            {
                throw new NotFoundException("Presença não encontrada.");
            }

            return new PresencaDto
            {
                Id = presencaId,
                AtletaId = presenca.AtletaId,
                TurmaId = presenca.TurmaId,
                DataHoraCadastro = presenca.DataHoraCadastro
            };
            

        }

        public async Task<List<PresencaDto>> ListarTodasAsync()
        {
            var presencas = await _PresencaRepository.ListarTodasAsync();
            return presencas.Select(pr => new PresencaDto
            {
                Id = pr.Id,
                AtletaId = pr.AtletaId,
                TurmaId = pr.TurmaId,
                DataHoraCadastro = pr.DataHoraCadastro

            }).ToList();
        }


        public async Task AtualizarAsync(PresencaDto dto)
        {

            var presenca = await ValidaPresenca(dto.Id);

            await _PresencaRepository.AtualizarAsync(presenca);
        }

        public async Task<List<PresencaDto>> ListarPresencasPorTurmaAsync(long turmaId)
        {

            var turma = await _TurmaService.ValidaTurma(turmaId);

            var presenca = await _PresencaRepository.ListarPorTurmaId(turmaId);
            return presenca.Select(pr => new PresencaDto
            {
                Id = pr.Id,
                AtletaId = pr.AtletaId,
                TurmaId = pr.TurmaId,
                DataHoraCadastro = pr.DataHoraCadastro

            }).ToList();
        }

        public async Task<List<PresencaDto>> ListarPresencasPorAtletaAsync(long atletaId)
        {

            var atleta = await _AtletaService.ValidaAtleta(atletaId);

            var presenca = await _PresencaRepository.ListarPorAtletaId(atletaId);
            return presenca.Select(pr => new PresencaDto
            {
                Id = pr.Id,
                AtletaId = pr.AtletaId,
                TurmaId = pr.TurmaId,
                DataHoraCadastro = pr.DataHoraCadastro

            }).ToList();
        }

        public async Task<Presenca> ValidaPresenca(long id)
        {
                
           var presenca = await _PresencaRepository.ListarPorId((long)id);

           if (presenca == null)
           {
               throw new BusinessRuleException("Presença não encontrada.");
           }

           return presenca;
                      
        }


        //Depois vou melhorar colocando um parametro ajustavel pra comparar o limite de tempo para marcar presença
        public async Task<bool> ValidaPresencaAlunoHorario(long turmaId,DateOnly dataPresenca,bool isProfessor)
        {
            var turma = await _TurmaService.ListarPorId(turmaId);

            var dataHoraAula = dataPresenca.ToDateTime(turma.HoraInicioAula);
            var agora = DateTime.Now;

            if (isProfessor)
            {
                if (agora < dataHoraAula)
                {
                    throw new BusinessRuleException("A presença não pode ser marcada antes do horário da aula.");
                }

                if (agora > dataHoraAula.AddHours(24))
                {
                    throw new BusinessRuleException("A presença só pode ser marcada em até 24 horas após o horário da aula.");
                }

                return true;
            }

            // Regra do aluno: só pode marcar entre 10 min antes e 10 min depois do início da aula
            if (agora < dataHoraAula.AddMinutes(-10))
            {
                throw new BusinessRuleException("A presença para a aula é liberada 10 minutos antes do horário definido.");
            }

            if (agora > dataHoraAula.AddMinutes(10))
            {
                throw new BusinessRuleException("O treino já começou. Solicite a um professor para marcar sua presença depois.");
            }

            return true;
        }

    }

}
