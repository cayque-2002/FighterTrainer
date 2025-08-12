using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterTrainer.Application.Interfaces;
using FighterTrainer.Domain.Entities;
using FighterTrainer.Domain.Interfaces;
using FighterTrainer.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace FighterTrainer.Application.Services
{
    public class FichaTreinoService : IFichaTreinoService
    {
        private readonly IFichaTreinoRepository _FichaTreinoRepository;
        private readonly ITurmaRepository _TurmaRepository;


        public FichaTreinoService(
        IFichaTreinoRepository fichaTreinoRepository, ITurmaRepository turmaRepository)
        {
            _FichaTreinoRepository = fichaTreinoRepository;
            _TurmaRepository = turmaRepository;
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

                    throw new Exception("Turma não tem mais vagas abertas.");

                }

            }

             throw new Exception("Turma não tem vagas abertas.");

        }

        public async Task<FichaTreinoDto> ListarPorId(long fichaTreinoId)
        {
            var fichaTreino = await _FichaTreinoRepository.ListarPorId(fichaTreinoId);
            if (fichaTreino == null)
            {
                throw new Exception("Ficha não encontrada.");
            }
            else
            {
                return new FichaTreinoDto
                {
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
                throw new Exception("Ficha não encontrada.");
            }

            await _FichaTreinoRepository.AtualizarAsync(fichaTreino);
        }


    }

}
