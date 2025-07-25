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
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _repository;

        public CidadeService(ICidadeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CidadeDto>> ListarTodasAsync()
        {
            var cidades = await _repository.GetAllAsync();
            return cidades.Select(c => new CidadeDto
            {
                Id = c.Id, 
                Nome = c.Nome,
                Estado = c.Estado
            }).ToList();
        }

        public async Task<CidadeDto> ListarPorId(long cidadeId)
        {
            var cidade = await _repository.ObterPorIdAsync(cidadeId);
            if (cidade == null)
            {
                throw new Exception("Graduação não encontrada.");
            }
            else
            {
                return new CidadeDto
                {
                    Id = cidade.Id,
                    Nome = cidade.Nome,
                    Estado = cidade.Estado

                };
            }

        }

    }


}
