using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterTrainer.Application.Interfaces;
using FighterTrainer.Domain.Entities;
using FighterTrainer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

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

            vinculoExistente.Where(x => x.ModalidadeId == dto.ModalidadeId);
            if (vinculoExistente is not null)
                throw new Exception("Aluno já cadastrado nessa modalidade!");

            // Cria usuário
            var usuarioModalidade = new UsuarioModalidade(dto.UsuarioId, dto.ModalidadeId, dto.GraduacaoId, dto.DataInicio, dto.Ativo);
            await _usuarioModalidadeRepository.AdicionarAsync(usuarioModalidade);

        }

        public async Task<IEnumerable<UsuarioModalidade>> ListarPorUsuario(long usuarioId)
        {
            var usuarioModalidades = await _usuarioModalidadeRepository.ObterPorUsuarioIdAsync(usuarioId);
            return usuarioModalidades;
                
        }

        public async Task InativarAsync(long usuarioId, long modalidadeId)
        {
            var usuarioModalidade = await _usuarioModalidadeRepository.ObterPorUsuarioIdAsync(usuarioId);

            var validaVinculo = usuarioModalidade.Where(x => x.ModalidadeId == modalidadeId).First();
           
                if (validaVinculo == null)
                    throw new Exception("Modalidade não encontrada");

            validaVinculo.Inativar();
            await _usuarioModalidadeRepository.InativarAsync(usuarioId, modalidadeId); 
             
        }

    }

}
