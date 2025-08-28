using FighterTrainer.Application.Interfaces;
using FighterTrainer.Domain.Entities;
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
    public class UsuarioModalidadeService : IUsuarioModalidadeService
    {
        private readonly IUsuarioModalidadeRepository _usuarioModalidadeRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPasswordHasher _passwordHasher;


        public UsuarioModalidadeService(
        IUsuarioRepository usuarioRepository,
        IUsuarioModalidadeRepository usuarioModalidadeRepository,
        IPasswordHasher passwordHasher)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioModalidadeRepository = usuarioModalidadeRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task AdicionarAsync(UsuarioModalidadeDto dto)
        {
            // Verifica duplicidade de e-mail
            var vinculoExistente = await _usuarioModalidadeRepository.ObterPorUsuarioIdAsync(dto.UsuarioId);

            vinculoExistente.Where(x => x.ModalidadeId == dto.ModalidadeId).FirstOrDefault();
            if (vinculoExistente.Count() > 0)
                throw new BusinessRuleException("Aluno já cadastrado nessa modalidade!");

            // Cria usuário
            var usuarioModalidade = new UsuarioModalidade(dto.UsuarioId, dto.ModalidadeId, dto.GraduacaoId, dto.DataInicio, dto.Ativo);
            await _usuarioModalidadeRepository.AdicionarAsync(usuarioModalidade);

        }

        public async Task<List<UsuarioModalidade>> ListarPorUsuario(long usuarioId)
        {
            var usuarioModalidades = await _usuarioModalidadeRepository.ObterPorUsuarioIdAsync(usuarioId);
            return usuarioModalidades;
                
        }

        public async Task<List<UsuarioModalidade>> ListarPorId(long id)
        {
            var usuarioModalidades = await _usuarioModalidadeRepository.ObterPorIdAsync(id);
            return usuarioModalidades;

        }

        public async Task InativarAsync(long id)
        {
            var usuarioModalidade = await _usuarioModalidadeRepository.ObterPorIdAsync(id);

            var validaVinculo = usuarioModalidade.First();
           
                if (validaVinculo == null)
                    throw new NotFoundException("Modalidade não encontrada");

            validaVinculo.Inativar();
            await _usuarioModalidadeRepository.InativarAsync(id); 
             
        }

        public async Task AtivarAsync(long id)
        {
            var usuarioModalidade = await _usuarioModalidadeRepository.ObterPorIdAsync(id);

            var validaVinculo = usuarioModalidade.First();

            if (validaVinculo == null)
                throw new NotFoundException("Modalidade não encontrada");

            validaVinculo.Ativar();
            await _usuarioModalidadeRepository.AtivarAsync(id);

        }

    }

}
