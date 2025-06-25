using System;
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
            var graduacoes = await _repository.GetAllAsync();
            return graduacoes.Select(m => new FederacaoDto
            {
                Id = m.Id, 
                Descricao = m.Descricao

            }).ToList();
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
    }


}
