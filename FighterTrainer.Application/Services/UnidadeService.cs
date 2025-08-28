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
    public class UnidadeService : IUnidadeService
    {
        private readonly IUnidadeRepository _unidadeRepository;

        public UnidadeService(
        IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository;
        }

        public async Task<UnidadeDto> CriarAsync(UnidadeDto dto)
        {
            var unidade = new Unidade(dto.Descricao, dto.CidadeId, dto.DataCriacao, dto.Ativo);
            await _unidadeRepository.AddAsync(unidade);

            return new UnidadeDto
            {
                Descricao = dto.Descricao,
                CidadeId = dto.CidadeId,
                DataCriacao = dto.DataCriacao,
                Ativo = dto.Ativo
            };
        }

        public async Task<UnidadeDto> ListarPorId(long unidadeId)
        {
            var unidade = await _unidadeRepository.ListarPorId(unidadeId);
            if (unidade == null)
            {
                throw new NotFoundException("Usuário não encontrado.");
            }
            else
            {
                return new UnidadeDto
                {
                    Id = unidade.Id,
                    Ativo = unidade.Ativo,
                    CidadeId = unidade.CidadeId,
                    DataCriacao = unidade.DataCriacao,
                    Descricao = unidade.Descricao
                };
            }
            
        }

        public async Task<List<UnidadeDto>> ListarTodasAsync()
        {
            var unidade = await _unidadeRepository.ListarTodasAsync();
            return unidade.Select(u => new UnidadeDto
            {
                Id = u.Id,
                Ativo = u.Ativo,
                CidadeId = u.CidadeId,
                DataCriacao = u.DataCriacao,
                Descricao = u.Descricao
            }).ToList();
        }
        public async Task AtualizarAsync(UnidadeDto dto)
        {
            var unidade = await _unidadeRepository.ListarPorId(dto.Id);

            if (unidade == null)
                throw new NotFoundException("Unidade não encontrada.");

            await _unidadeRepository.AtualizarAsync(unidade);
        }

        public async Task<bool> RemoverAsync(long id)
        {
            var unidade = await _unidadeRepository.ListarPorId(id);
            if (unidade == null) return false;

            await _unidadeRepository.RemoverAsync(unidade.Id);
            return true;
        }

        public async Task InativarAsync(long id)
        {
            var unidade = await _unidadeRepository.ListarPorId(id);
            if (unidade == null)
                throw new NotFoundException("Usuário não encontrado");

            unidade.Inativar();
            await _unidadeRepository.InativarAsync(id);
        }





    }

}
