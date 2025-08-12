using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterTrainer.Application.Interfaces;
using FighterTrainer.Domain.Entities;
using FighterTrainer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FighterTrainer.Application.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _TurmaRepository;

        public TurmaService(
        ITurmaRepository turmaRepository)
        {
            _TurmaRepository = turmaRepository;
        }

        public async Task<TurmaDto> CriarAsync(TurmaDto dto)
        {
            var Turma = new Turma(dto.UnidadeId,dto.Descricao,dto.HoraInicioAula,dto.HoraFimAula,dto.TreinadorResponsavelId,dto.DataCriacao,dto.Ativo, dto.LimiteAlunos);
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
            var turma = await _TurmaRepository.ListarPorId(turmaId);
            if (turma == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            else
            {
                return new TurmaDto
                {
                    UnidadeId = turma.UnidadeId,
                    Descricao = turma.Descricao,
                    HoraInicioAula = turma.HoraInicioAula,
                    HoraFimAula = turma.HoraFimAula,
                    TreinadorResponsavelId = turma.TreinadorResponsavelId,
                    DataCriacao = turma.DataCriacao,
                    Ativo = turma.Ativo
                };
            }
            
        }

        public async Task<List<TurmaDto>> ListarTodasAsync()
        {
            var turma = await _TurmaRepository.ListarTodasAsync();
            return turma.Select(t => new TurmaDto
            {
                UnidadeId = t.UnidadeId,
                Descricao = t.Descricao,
                HoraInicioAula = t.HoraInicioAula,
                HoraFimAula = t.HoraFimAula,
                TreinadorResponsavelId = t.TreinadorResponsavelId,
                DataCriacao = t.DataCriacao,
                Ativo = t.Ativo

            }).ToList();
        }
        public async Task AtualizarAsync(TurmaDto dto)
        {
            var turma = await _TurmaRepository.ListarPorId(dto.Id);

            if (turma == null)
                throw new Exception("Turma não encontrada.");

            await _TurmaRepository.AtualizarAsync(turma);
        }

        public async Task<bool> RemoverAsync(long id)
        {
            var turma = await _TurmaRepository.ListarPorId(id);
            if (turma == null) return false;

            await _TurmaRepository.RemoverAsync(turma.Id);
            return true;
        }

        public async Task InativarAsync(long id)
        {
            var turma = await _TurmaRepository.ListarPorId(id);
            if (turma == null)
                throw new Exception("Usuário não encontrado");

            turma.Inativar();
            await _TurmaRepository.InativarAsync(id);
        }

    }

}
