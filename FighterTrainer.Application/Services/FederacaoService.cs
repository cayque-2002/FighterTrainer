﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterTrainer.Application.Interfaces;
using FighterTrainer.Domain.Entities;
using FighterTrainer.Domain.Interfaces;

namespace FighterTrainer.Application.Services
{
    public class FederacaoService : IFederacaoService
    {
        private readonly IFederacaoRepository _repository;

        public FederacaoService(IFederacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FederacaoDto>> ListarTodasAsync()
        {
            var federacoes = await _repository.GetAllAsync();
            return federacoes.Select(m => new FederacaoDto
            {
                Id = m.Id, 
                Descricao = m.Descricao

            }).ToList();
        }

        public async Task<FederacaoDto> ListarPorId(long federacaoId)
        {
            var federacao = await _repository.ObterPorIdAsync(federacaoId);
            if (federacao == null)
            {
                throw new Exception("Federação não encontrada.");
            }
            else
            {
                return new FederacaoDto
                {
                    Id = federacao.Id,
                    Descricao = federacao.Descricao
                };
            }

        }

        public async Task<FederacaoDto> CriarAsync(FederacaoDto dto)
        {
            var federacao = new Federacao(dto.Descricao);
            await _repository.AddAsync(federacao);

            return new FederacaoDto
            {
                Id= dto.Id,
                Descricao = dto.Descricao,
                

            };
        }

        public async Task AtualizarAsync(FederacaoDto dto)
        {
            var federacao = await _repository.ObterPorIdAsync(dto.Id);

            if (federacao == null)
                throw new Exception("Federação não encontrada");

            federacao.Atualizar(dto.Descricao); // você precisa ter esse método na entidade

            await _repository.AtualizarAsync(federacao);
        }

        public async Task<bool> RemoverAsync(long id)
        {
            var usuario = await _repository.ObterPorIdAsync(id);
            if (usuario == null) return false;

            await _repository.RemoverAsync(usuario.Id);
            return true;
        }

    }


}
