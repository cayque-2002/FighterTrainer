using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterTrainer.Application.Interfaces;
using FighterTrainer.Domain.Entities;
using FighterTrainer.Domain.Interfaces;
using FighterTrainer.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace FighterTrainer.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioModalidadeRepository _usuarioModalidadeRepository;
        private readonly IPasswordHasher _passwordHasher;


        public UsuarioService(
        IUsuarioRepository usuarioRepository,
        IUsuarioModalidadeRepository usuarioModalidadeRepository,
        IPasswordHasher passwordHasher)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioModalidadeRepository = usuarioModalidadeRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<UsuarioDto> RegistrarUsuarioAsync(CreateUsuarioDto dto)
        {
            // Verifica duplicidade de e-mail
            var usuarioExistente = await _usuarioRepository.ObterPorEmailAsync(dto.Email);
            if (usuarioExistente is not null)
                throw new Exception("E-mail já cadastrado");

            // Hash da senha
            var senhaHash = _passwordHasher.Hash(dto.Senha);

            // Cria usuário
            var usuario = new Usuario(dto.Nome, dto.Email, senhaHash, dto.Tipo);
            await _usuarioRepository.AdicionarAsync(usuario);

            //await _usuarioModalidadeRepository.AdicionarAsync(usuarioModalidade);

            if (dto.Tipo == TipoUsuario.Aluno)
            {
                var atleta = new Atleta(usuario.Id);

                await _usuarioRepository.CriarAtleta(atleta);
            };

            // Retorno
            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Tipo = usuario.TipoUsuario
            };
        }

        public async Task<UsuarioDto> ListarPorId(long usuarioId)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(usuarioId);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            else
            {
                return new UsuarioDto
                {
                    Id = usuario.Id,
                    Ativo = usuario.Ativo,
                    Email = usuario.Email,
                    Nome = usuario.Nome,
                    Tipo = usuario.TipoUsuario
                };
            }
            
        }

        public async Task VincularUsuarioModalidadeAsync(long usuarioId, long modalidadeId, long graduacaoId)
        {

            var modalidadesUsuarioExistente = await _usuarioModalidadeRepository.ObterPorUsuarioIdAsync(usuarioId);
            foreach (var usuarioModalidade in modalidadesUsuarioExistente)
            {
                if (usuarioModalidade.ModalidadeId == modalidadeId && usuarioModalidade.GraduacaoId == graduacaoId)
                {
                    throw new Exception("Vínculo usuarioModalidade já existe");
                }
                else 
                {
                    var modalidadesUsuario = new UsuarioModalidade(usuarioId, modalidadeId, graduacaoId, usuarioModalidade.DataInicio, usuarioModalidade.Ativo);
                    await _usuarioModalidadeRepository.AdicionarAsync(modalidadesUsuario);
                }

            }
            
        }

        public async Task<List<UsuarioDto>> ListarTodosAsync()
        {
            var usuarios = await _usuarioRepository.ListarTodosAsync();
            return usuarios.Select(u => new UsuarioDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                Tipo = u.TipoUsuario
            }).ToList();
        }
        public async Task AtualizarAsync(UsuarioDto dto)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(dto.Id);

            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            usuario.AlterarNome(dto.Nome);
            usuario.AlterarEmail(dto.Email);
            usuario.AlterarTipoUsuario(dto.Tipo);

            await _usuarioRepository.AtualizarAsync(usuario);
        }

        public async Task<bool> RemoverAsync(long id)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(id);
            if (usuario == null) return false;

            await _usuarioRepository.RemoverAsync(usuario.Id);
            return true;
        }

        public async Task InativarAsync(long id)
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(id);
            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            usuario.Inativar();
            await _usuarioRepository.InativarAsync(id);
        }





    }

}
