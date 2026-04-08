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
using FighterTrainer.Domain.Exceptions;

namespace FighterTrainer.Application.Services
{
    public class AtletaService : IAtletaService
    {
        private readonly IAtletaRepository _AtletaRepository;
        private readonly IUsuarioService _UsuarioService;


        public AtletaService(
        IAtletaRepository atletaRepository, IUsuarioService usuarioService)
        {
            _AtletaRepository = atletaRepository;
            _UsuarioService = usuarioService;
        }

        public async Task<AtletaDto> AdicionarAsync(AtletaDto dto)
        {
            var atleta = new Atleta(dto.UsuarioId);
            await _AtletaRepository.AdicionarAsync(atleta);

            return new AtletaDto
            {
                UsuarioId = dto.UsuarioId,
                Apelido = dto.Apelido,
                Altura = dto.Altura,
                Peso = dto.Peso,
                Agilidade = dto.Agilidade,
                Defesa = dto.Defesa,
                FocoMental = dto.FocoMental,
                LutaEmPe = dto.LutaEmPe,
                Resistencia = dto.Resistencia,
                Solo = dto.Solo,
                Wrestling = dto.Wrestling
            };
        }

        public async Task<AtletaDto> ListarPorId(long atletaId)
        {
            var atleta = await _AtletaRepository.ListarPorId(atletaId);
            if (atleta == null)
            {
                throw new NotFoundException("Usuário não encontrado.");
            }
            else
            {
                return new AtletaDto
                {
                    Id = atleta.Id,
                    UsuarioId = atleta.UsuarioId,
                    Apelido = atleta.Apelido ?? string.Empty,
                    Altura = atleta.Altura,
                    Peso = atleta.Peso,
                    Agilidade = atleta.Agilidade,
                    Defesa = atleta.Defesa,
                    FocoMental = atleta.FocoMental,
                    LutaEmPe = atleta.LutaEmPe,
                    Resistencia = atleta.Resistencia,
                    Solo = atleta.Solo,
                    Wrestling = atleta.Wrestling
                };
            }

        }

        public async Task<List<AtletaDto>> ListarTodasAsync()
        {
            var atleta = await _AtletaRepository.ListarTodasAsync();
            return atleta.Select(a => new AtletaDto
            {
                Id = a.Id,
                UsuarioId = a.UsuarioId,
                Apelido = a.Apelido ?? string.Empty,
                Altura = a.Altura,
                Peso = a.Peso,
                Agilidade = a.Agilidade,
                Defesa = a.Defesa,
                FocoMental = a.FocoMental,
                LutaEmPe = a.LutaEmPe,
                Resistencia = a.Resistencia,
                Solo = a.Solo,
                Wrestling = a.Wrestling

            }).ToList();
        }
        public async Task AtualizarAsync(AtletaDto dto)
        {
            var atleta = await _AtletaRepository.ListarPorId(dto.Id);

            if (atleta == null)
            {
                throw new NotFoundException("Turma não encontrada.");
            }

            atleta.Peso = dto.Peso;
            atleta.Altura = dto.Altura;
            atleta.Apelido = dto.Apelido;
            atleta.Resistencia = dto.Resistencia;
            atleta.Agilidade = dto.Agilidade;
            atleta.Solo = dto.Solo;
            atleta.Wrestling = dto.Wrestling;
            atleta.FocoMental = dto.FocoMental;
            atleta.Defesa = dto.Defesa;
            atleta.LutaEmPe = dto.LutaEmPe;

            await _AtletaRepository.AtualizarAsync(atleta);
        }


        public async Task<Atleta> ValidaAtleta(long atletaId)
        {
            var atleta = await _AtletaRepository.ListarPorId(atletaId);
            if (atleta == null)
            {
                throw new NotFoundException("Atleta não encontrado.");
            }
            return atleta;
        }


    }

}
