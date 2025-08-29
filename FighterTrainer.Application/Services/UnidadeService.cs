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
        private readonly ICidadeService _cidadeService;

        public UnidadeService(
        IUnidadeRepository unidadeRepository, ICidadeService cidadeService)
        {
            _unidadeRepository = unidadeRepository;
            _cidadeService = cidadeService;
        }

        public async Task<UnidadeDto> CriarAsync(UnidadeDto dto)
        {
            var cidade = await _cidadeService.ValidaCidade(dto.CidadeId);

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
            var unidade = await ValidaUnidade(unidadeId);

            return new UnidadeDto
                {
                    Id = unidade.Id,
                    Ativo = unidade.Ativo,
                    CidadeId = unidade.CidadeId,
                    DataCriacao = unidade.DataCriacao,
                    Descricao = unidade.Descricao
                };
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
            var unidade = await ValidaUnidade(dto.Id);

            if (unidade.CidadeId != dto.CidadeId) 
            {
                //validar existência cidade
                var cidade = await _cidadeService.ValidaCidade(dto.CidadeId);
            }
            

            await _unidadeRepository.AtualizarAsync(unidade);
        }

        public async Task<bool> RemoverAsync(long id)
        {
            var unidade = await ValidaUnidade(id);

            await _unidadeRepository.RemoverAsync(unidade.Id);
            return true;
        }

        public async Task InativarAsync(long id)
        {
            var unidade = await ValidaUnidade(id);
           
            unidade.Inativar();
            await _unidadeRepository.InativarAsync(id);
        }

        public async Task<Unidade> ValidaUnidade(long id)
        {
            var unidade = await _unidadeRepository.ListarPorId(id);
            if (unidade == null)
                throw new NotFoundException("Unidade não encontrada.");

            return unidade;
        }

    }

}
