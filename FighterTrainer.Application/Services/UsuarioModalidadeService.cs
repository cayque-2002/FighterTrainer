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
        private readonly IAtletaService _atletaService;



        public UsuarioModalidadeService(
        IUsuarioRepository usuarioRepository,
        IUsuarioModalidadeRepository usuarioModalidadeRepository,
        IPasswordHasher passwordHasher,IAtletaService atletaService)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioModalidadeRepository = usuarioModalidadeRepository;
            _passwordHasher = passwordHasher;
            _atletaService = atletaService;
        }

        public async Task AdicionarAsync(UsuarioModalidadeDto dto)
        {
            // Verifica se aluno ja cadastrado pra modalidade.
            await ValidaVinculoModalidade(dto.UsuarioId,dto.ModalidadeId);

            // Cria usuário modalidade
            var usuarioModalidade = new UsuarioModalidade(dto.UsuarioId, dto.ModalidadeId, dto.GraduacaoId, dto.DataInicio, dto.Ativo);
            await _usuarioModalidadeRepository.AdicionarAsync(usuarioModalidade);

        }

        public async Task<List<UsuarioModalidade>> ListarPorUsuario(long usuarioId)
        {
            var usuarioModalidades = await _usuarioModalidadeRepository.ObterPorUsuarioIdAsync(usuarioId);
            return usuarioModalidades;
                
        }

        public async Task<UsuarioModalidade> ListarPorId(long id)
        {
            var usuarioModalidades = await ValidaUsuarioModalidade(id);
            return usuarioModalidades;
        }

        public async Task InativarAsync(long id)
        {
            var usuarioModalidade = await ValidaUsuarioModalidade(id);

            usuarioModalidade.Inativar();
            await _usuarioModalidadeRepository.InativarAsync(id); 
             
        }

        public async Task AtivarAsync(long id)
        {
            var usuarioModalidade = await ValidaUsuarioModalidade(id);

            usuarioModalidade.Ativar();
            await _usuarioModalidadeRepository.AtivarAsync(id);

        }

        public async Task<UsuarioModalidade> ValidaUsuarioModalidade(long id)
        {
            var usuarioModalidade = await _usuarioModalidadeRepository.ObterPorIdAsync(id);
            if (usuarioModalidade == null)
            {
                throw new NotFoundException("UsuárioModalidade não encontrado.");
            }
            return usuarioModalidade;
        }


        public async Task<UsuarioModalidade> ValidaVinculoUsuarioAtletaModalidade(long usuarioModalidadeId, long atletaId)
        {

            var usuarioModalidade = await ValidaUsuarioModalidade(usuarioModalidadeId);

            var atleta = await _atletaService.ListarPorId(atletaId);

            if (usuarioModalidade.UsuarioId != atleta.UsuarioId)
            {
                throw new NotFoundException("O atleta não pertence ao usuário informado na modalidade.");
            }

            return usuarioModalidade;
        }

        public async Task ValidaVinculoModalidade(long usuarioId, long modalidadeId)
        {
            var usuarioModalidade = await ListarPorUsuario(usuarioId);

            if (usuarioModalidade.Any(x => x.ModalidadeId == modalidadeId))
            {
                throw new NotFoundException("Aluno já cadastrado nessa modalidade!");
            }

        }


    }

}
