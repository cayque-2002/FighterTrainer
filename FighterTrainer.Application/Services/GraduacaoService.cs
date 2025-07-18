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

        public async Task<GraduacaoDto> ListarPorId(long graduacaoId)
        {
            var graduacao = await _repository.ObterPorIdAsync(graduacaoId);
            if (graduacao == null)
            {
                throw new Exception("Graduação não encontrada.");
            }
            else
            {
                return new GraduacaoDto
                {
                    Id = graduacaoId,
                    Descricao = graduacao.Descricao,
                    FederacaoId= graduacao.FederacaoId,
                    Grau = graduacao.Grau ?? 0,
                    ModalidadeId = graduacao.ModalidadeId,   
                    Nivel = graduacao.Nivel

                };
            }

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
        public async Task AtualizarAsync(GraduacaoDto dto)
        {
            var graduacao = await _repository.ObterPorIdAsync(dto.Id);

            if (graduacao == null)
                throw new Exception("Graduação não encontrada");

            graduacao.Atualizar(dto.Descricao, dto.Nivel, dto.Grau, dto.ModalidadeId, dto.FederacaoId);

            await _repository.AtualizarAsync(graduacao);
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
