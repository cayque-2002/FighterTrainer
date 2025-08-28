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
    public class FichaTreinoService : IFichaTreinoService
    {
        private readonly IFichaTreinoRepository _FichaTreinoRepository;
        private readonly ITurmaRepository _TurmaRepository;
        private readonly IAtletaRepository _AtletaRepository;
        private readonly IUsuarioModalidadeRepository _UsuarioModalidadeRepository;


        public FichaTreinoService(
        IFichaTreinoRepository fichaTreinoRepository, ITurmaRepository turmaRepository, 
        IAtletaRepository atletaRepository, IUsuarioModalidadeRepository usuarioModalidadeRepository)
        {
            _FichaTreinoRepository = fichaTreinoRepository;
            _TurmaRepository = turmaRepository;
            _AtletaRepository = atletaRepository;
            _UsuarioModalidadeRepository = usuarioModalidadeRepository;
        }

        public async Task<FichaTreinoDto> AdicionarAsync(FichaTreinoDto dto)
        {
            var turma = await _TurmaRepository.ListarPorId(dto.TurmaId);

            if (turma.LimiteAlunos > 0)
            {
                // fazer um service de validação de quantidade de alunos cadastrado na turma.
                var alunosTurma = await _FichaTreinoRepository.ListarTodasAsync();

                var quantidadeAlunosTurma = alunosTurma.Where(x => x.TurmaId == turma.Id).Count();

                if (quantidadeAlunosTurma < turma.LimiteAlunos) 
                {

                    var validaFicha = await _FichaTreinoRepository.ListarTreinosPorAtleta(dto.AtletaId);

                    var atleta = await _AtletaRepository.ListarPorId(dto.AtletaId);
                    if (atleta == null)
                        throw new NotFoundException("Atleta não encontrado.");

                    var usuarioModalidade = await _UsuarioModalidadeRepository.ObterPorIdAsync(dto.UsuarioModalidadeId);
                    if (usuarioModalidade == null)
                        throw new NotFoundException("UsuárioModalidade não encontrado.");

                    // valida se o atleta realmente pertence ao usuário da modalidade
                    var validaVinculo = usuarioModalidade.Where(x => x.Id == dto.UsuarioModalidadeId).Select(x => x.UsuarioId).FirstOrDefault();

                    if ( validaVinculo != atleta.UsuarioId)
                        throw new BusinessRuleException("O atleta não pertence ao usuário informado na modalidade.");


                    if (validaFicha.Where(x => x.UsuarioModalidadeId == dto.UsuarioModalidadeId).Count() > 1) 
                    {
                        throw new BusinessRuleException("Atleta ja tem ficha de treino para esta modalidade.");
                    }

                    if (validaFicha.Where(x => x.TurmaId == dto.TurmaId).Count() > 1)
                    {
                        throw new BusinessRuleException("Atleta ja tem ficha de treino para esta Turma.");
                    }

                    var fichaTreino = new FichaTreino(dto.AtletaId, dto.UsuarioModalidadeId, dto.Nivel, dto.Descricao, dto.TurmaId);
                    await _FichaTreinoRepository.AdicionarAsync(fichaTreino);

                    return new FichaTreinoDto
                    {
                        AtletaId = dto.AtletaId,
                        UsuarioModalidadeId = dto.UsuarioModalidadeId,
                        Nivel = dto.Nivel,
                        Descricao = dto.Descricao,
                        TurmaId = dto.TurmaId
                    };
                }
                else 
                {

                    throw new NotFoundException("Turma não tem mais vagas abertas.");

                }

            }

             throw new BusinessRuleException("Turma não tem vagas abertas.");

        }

        public async Task<FichaTreinoDto> ListarPorId(long fichaTreinoId)
        {
            var fichaTreino = await _FichaTreinoRepository.ListarPorId(fichaTreinoId);
            if (fichaTreino == null)
            {
                throw new NotFoundException("Ficha não encontrada.");
            }
            else
            {
                return new FichaTreinoDto
                {
                    Id = fichaTreino.Id,
                    AtletaId = fichaTreino.AtletaId,
                    UsuarioModalidadeId = fichaTreino.UsuarioModalidadeId,
                    Nivel = fichaTreino.Nivel,
                    Descricao = fichaTreino.Descricao,
                    TurmaId = fichaTreino.TurmaId
                };
            }

        }

        public async Task<List<FichaTreinoDto>> ListarTodasAsync()
        {
            var fichaTreino = await _FichaTreinoRepository.ListarTodasAsync();
            return fichaTreino.Select(ft => new FichaTreinoDto
            {
                Id = ft.Id,
                AtletaId = ft.AtletaId,
                UsuarioModalidadeId = ft.UsuarioModalidadeId,
                Nivel = ft.Nivel,
                Descricao = ft.Descricao,
                TurmaId = ft.TurmaId

            }).ToList();
        }
        public async Task AtualizarAsync(FichaTreinoDto dto)
        {
            var fichaTreino = await _FichaTreinoRepository.ListarPorId(dto.Id);

            if (fichaTreino == null)
            {
                throw new NotFoundException("Ficha não encontrada.");
            }

            await _FichaTreinoRepository.AtualizarAsync(fichaTreino);
        }

        public async Task<List<FichaTreinoDto>> ListarAlunosPorTurmaAsync(long turmaId)
        {
            var fichaTreino = await _FichaTreinoRepository.ListarAlunosPorTurmaAsync(turmaId);
            return fichaTreino.Select(ft => new FichaTreinoDto
            {
                Id = ft.Id,
                AtletaId = ft.AtletaId,
                UsuarioModalidadeId = ft.UsuarioModalidadeId,
                Nivel = ft.Nivel,
                Descricao = ft.Descricao,
                TurmaId = ft.TurmaId

            }).ToList();
        }

        public async Task<List<FichaTreinoDto>> ListarTreinosPorAtleta(long atletaId)
        {
            var fichaTreino = await _FichaTreinoRepository.ListarTreinosPorAtleta(atletaId);

            if (fichaTreino == null) 
            {
                throw new BusinessRuleException("Atleta não possui ficha treino.");
            }
            return fichaTreino.Select(ft => new FichaTreinoDto
            {   
                Id = ft.Id,
                AtletaId = ft.AtletaId,
                UsuarioModalidadeId = ft.UsuarioModalidadeId,
                Nivel = ft.Nivel,
                Descricao = ft.Descricao,
                TurmaId = ft.TurmaId

            }).ToList();
        }



    }

}
