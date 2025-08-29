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
        private readonly IAtletaService _AtletaService;
        private readonly IUsuarioModalidadeService _UsuarioModalidadeService;
        private readonly ITurmaService _TurmaService;


        public FichaTreinoService(
        IFichaTreinoRepository fichaTreinoRepository, ITurmaRepository turmaRepository, 
        IAtletaRepository atletaRepository, IUsuarioModalidadeRepository usuarioModalidadeRepository, IAtletaService atletaService, IUsuarioModalidadeService usuarioModalidadeService,ITurmaService turmaService )
        {
            _FichaTreinoRepository = fichaTreinoRepository;
            _TurmaRepository = turmaRepository;
            _AtletaRepository = atletaRepository;
            _UsuarioModalidadeRepository = usuarioModalidadeRepository;
            _AtletaService = atletaService;
            _UsuarioModalidadeService = usuarioModalidadeService;
            _TurmaService = turmaService;
        }

        public async Task<FichaTreinoDto> AdicionarAsync(FichaTreinoDto dto)
        {
            //valida se a Turma existe
            var turma = await _TurmaService.ValidaTurma(dto.TurmaId);

            if (turma.LimiteAlunos > 0)
            {
                // fazer um service de validação de quantidade de alunos cadastrado na turma.
                var alunosTurma = await _FichaTreinoRepository.ListarAlunosPorTurmaAsync(dto.TurmaId);

                //var quantidadeAlunosTurma = alunosTurma.Where(x => x.TurmaId == turma.Id).Count();

                if (alunosTurma.Count() < turma.LimiteAlunos) 
                {
                    //valida se o atleta existe
                    var atleta = await _AtletaService.ValidaAtleta( dto.AtletaId);

                    // valida se o atleta realmente pertence ao usuário da modalidade
                    var validaVinculo = await _UsuarioModalidadeService.ValidaVinculoUsuarioAtletaModalidade(dto.UsuarioModalidadeId, dto.AtletaId);

                    //valida regras de vinculo do atleta com turma ou modalidade
                    await ValidaVinculoFichaTreino(atleta.Id,validaVinculo.Id,turma.Id);

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
            //var fichaTreino = await _FichaTreinoRepository.ListarPorId(fichaTreinoId);
            //if (fichaTreino == null)
            //{
            //    throw new NotFoundException("Ficha não encontrada.");
            //}
            var fichaTreino = await ValidaFichaTreino(fichaTreinoId);

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
           // var fichaTreino = await _FichaTreinoRepository.ListarPorId(dto.Id);

            var fichaTreino = await ValidaFichaTreino(dto.Id);

            //if (fichaTreino == null)
            //{
            //    throw new NotFoundException("Ficha não encontrada.");
            //}

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

        public async Task<FichaTreino> ValidaFichaTreino(long id)
        {
                
           var fichaTreino = await _FichaTreinoRepository.ListarPorId((long)id);

           if (fichaTreino == null)
           {
               throw new BusinessRuleException("Ficha Treino não encontrada.");
           }

           return fichaTreino;
                      
        }

        public async Task ValidaVinculoFichaTreino(long atletaId, long usuarioModalidadeId, long turmaId)
        {
            var fichaTreino = await _FichaTreinoRepository.ListarTreinosPorAtleta(atletaId);


            if (fichaTreino.Any(x => x.UsuarioModalidadeId == usuarioModalidadeId))
            {
                throw new BusinessRuleException("Atleta ja tem ficha de treino para esta modalidade.");
            }

            if (fichaTreino.Any(x => x.TurmaId == turmaId))
            {
                throw new BusinessRuleException("Atleta ja tem ficha de treino para esta Turma.");
            }

            return;
        }



    }

}
