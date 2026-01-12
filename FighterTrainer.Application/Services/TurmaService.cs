using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterTrainer.Application.Interfaces;
using FighterTrainer.Domain.Entities;
using FighterTrainer.Domain.Exceptions;
using FighterTrainer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FighterTrainer.Application.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _TurmaRepository;
        private readonly ITreinadorRepository _TreinadorRepository;
        private readonly ITreinadorService  _TreinadorService;

        public TurmaService(
        ITurmaRepository turmaRepository,ITreinadorRepository treinadorRepository, ITreinadorService treinadorService)
        {
            _TurmaRepository = turmaRepository;
            _TreinadorRepository = treinadorRepository;
            _TreinadorService = treinadorService;
        }

        public async Task<TurmaDto> CriarAsync(TurmaDto dto)
        {
            var Turma = new Turma(dto.UnidadeId,dto.Descricao,dto.HoraInicioAula,dto.HoraFimAula,dto.TreinadorResponsavelId,dto.DataCriacao,dto.Ativo, dto.LimiteAlunos);

            var treinador = await _TreinadorService.ValidaTreinador(dto.TreinadorResponsavelId);

            await ValidaModalidadeHorarioTurma(dto.ModalidadeId, dto.UnidadeId, dto.HoraInicioAula, dto.HoraFimAula);

            await _TurmaRepository.AddAsync(Turma);

            return new TurmaDto
            {
                UnidadeId = dto.UnidadeId,
                Descricao = dto.Descricao,
                HoraInicioAula = dto.HoraInicioAula,
                HoraFimAula = dto.HoraFimAula,
                TreinadorResponsavelId = dto.TreinadorResponsavelId,
                DataCriacao = dto.DataCriacao,
                Ativo = dto.Ativo,
                LimiteAlunos = dto.LimiteAlunos
            };

        }

        public async Task<TurmaDto> ListarPorId(long turmaId)
        {
            var turma = await ValidaTurma(turmaId);
            
                return new TurmaDto
                {
                    Id = turma.Id,
                    UnidadeId = turma.UnidadeId,
                    Descricao = turma.Descricao,
                    HoraInicioAula = turma.HoraInicioAula,
                    HoraFimAula = turma.HoraFimAula,
                    TreinadorResponsavelId = turma.TreinadorResponsavelId,
                    DataCriacao = turma.DataCriacao,
                    Ativo = turma.Ativo,
                    LimiteAlunos = turma.LimiteAlunos
                    
                };
            
            
        }

        public async Task<List<TurmaDto>> ListarTodasAsync()
        {
            var turma = await _TurmaRepository.ListarTodasAsync();
            return turma.Select(t => new TurmaDto
            {
                Id = t.Id,
                UnidadeId = t.UnidadeId,
                Descricao = t.Descricao,
                HoraInicioAula = t.HoraInicioAula,
                HoraFimAula = t.HoraFimAula,
                TreinadorResponsavelId = t.TreinadorResponsavelId,
                DataCriacao = t.DataCriacao,
                Ativo = t.Ativo,
                LimiteAlunos = t.LimiteAlunos,
                ModalidadeId = t.ModalidadeId

            }).ToList();
        }
        public async Task AtualizarAsync(TurmaDto dto)
        {
            var turma = await ValidaTurma(dto.Id);

            //colocar valida modalidade

            turma.Ativo = dto.Ativo;
            turma.HoraInicioAula = dto.HoraInicioAula;
            turma.HoraFimAula = dto.HoraFimAula;
            turma.Descricao = dto.Descricao;
            turma.LimiteAlunos = dto.LimiteAlunos;
            turma.ModalidadeId = dto.ModalidadeId;
            
            if(dto.TreinadorResponsavelId != turma.TreinadorResponsavelId) 
            {
                var treinador = await _TreinadorService.ValidaTreinador(dto.TreinadorResponsavelId);

                turma.TreinadorResponsavelId = treinador.Id;
            }

            await ValidaModalidadeHorarioTurma(dto.ModalidadeId, dto.UnidadeId, dto.HoraInicioAula, dto.HoraFimAula);
            
            await _TurmaRepository.AtualizarAsync(turma);
        }

        public async Task<bool> RemoverAsync(long id)
        {
            var turma = await ValidaTurma(id);

            await _TurmaRepository.RemoverAsync(turma.Id);
            return true;
        }

        public async Task InativarAsync(long id)
        {
            var turma = await ValidaTurma(id);

            turma.Inativar();
            await _TurmaRepository.InativarAsync(id);
        }

        public async Task<Turma> ValidaTurma(long id)
        {
            var turma = await _TurmaRepository.ListarPorId(id);
            if (turma == null)
                throw new NotFoundException("Turma não encontrada.");

            return turma;
        }

        public async Task ValidaModalidadeHorarioTurma(long modalidadeId, long unidadeId,TimeOnly horaInicioAula, TimeOnly horaFimAula)
        {
            var turma = await _TurmaRepository.ListarTodasAsync();
            if (turma.Any(x => x.ModalidadeId == modalidadeId && x.UnidadeId == unidadeId && horaInicioAula <= x.HoraFimAula && x.HoraInicioAula <= horaFimAula))
                throw new BusinessRuleException("Já tem uma turma desta modalidade nesse período.");

            return ;
        }
        
    }

}
