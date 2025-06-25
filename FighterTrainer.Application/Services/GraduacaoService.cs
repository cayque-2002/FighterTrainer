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
    public class GraduacaoService : IGraduacaoService
    {
        private readonly IGraduacaoRepository _repository;

        public GraduacaoService(IGraduacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GraduacaoDto>> ListarTodasAsync()
        {
            var graduacoes = await _repository.GetAllAsync();
            return graduacoes.Select(m => new GraduacaoDto
            {
                Id = m.Id, 
                Descricao = m.Descricao,
                FederacaoId = m.FederacaoId,
                ModalidadeId = m.ModalidadeId,
                Grau = m.Grau ?? 0,
                Nivel = m.Nivel

            }).ToList();
        }

        public async Task<GraduacaoDto> CriarAsync(GraduacaoDto dto)
        {
            var graduacao = new Graduacao(dto.ModalidadeId,dto.Descricao,dto.Nivel,dto.Grau, dto.FederacaoId);
            await _repository.AddAsync(graduacao);

            return new GraduacaoDto
            {
                Id= dto.Id,
                Descricao = dto.Descricao,
                Nivel= dto.Nivel,
                FederacaoId= dto.FederacaoId,
                Grau = dto.Grau,
                ModalidadeId = dto.ModalidadeId

            };
        }
    }


}
