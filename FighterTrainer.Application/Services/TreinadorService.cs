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
    public class TreinadorService : ITreinadorService
    {
        private readonly ITreinadorRepository _TreinadorRepository;


        public TreinadorService(
        ITreinadorRepository treinadorRepository)
        {
            _TreinadorRepository = treinadorRepository;
        }

        //public async Task<TreinadorDto> AdicionarAsync(TreinadorDto dto)
        //{
        //    var treinador = new Treinador(dto.UsuarioId);
        //    await _TreinadorRepository.AdicionarAsync(treinador);

        //    return new TreinadorDto
        //    {
                
        //        UsuarioId = dto.UsuarioId,
        //        Apelido = dto.Apelido,
        //        Altura = dto.Altura,
        //        Peso = dto.Peso,
        //        Agilidade = dto.Agilidade,
        //        Defesa = dto.Defesa,
        //        FocoMental = dto.FocoMental,
        //        LutaEmPe = dto.LutaEmPe,
        //        Resistencia = dto.Resistencia,
        //        Solo = dto.Solo,
        //        Wrestling = dto.Wrestling
        //    };
        //}

        public async Task<TreinadorDto> ListarPorId(long id)
        {
            var treinador = await _TreinadorRepository.ListarPorId(id);
            if (treinador == null)
            {
                throw new Exception("Treinador não encontrado.");
            }
            else
            {
                return new TreinadorDto
                {
                    Id = treinador.Id,
                    UsuarioId = treinador.UsuarioId,
                };
            }

        }

        public async Task<List<TreinadorDto>> ListarTodasAsync()
        {
            var treinador = await _TreinadorRepository.ListarTodasAsync();
            return treinador.Select(t => new TreinadorDto
            {
                Id = t.Id,
                UsuarioId = t.UsuarioId

            }).ToList();
        }
        //public async Task AtualizarAsync(TreinadorDto dto)
        //{
        //    var treinador = await _TreinadorRepository.ListarPorId(dto.Id);

        //    if (treinador == null)
        //    {
        //        throw new Exception("Turma não encontrada.");
        //    }

        //    treinador.Peso = dto.Peso;
        //    treinador.Altura = dto.Altura;
        //    treinador.Apelido = dto.Apelido;
        //    treinador.Resistencia = dto.Resistencia;
        //    treinador.Agilidade = dto.Agilidade;
        //    treinador.Solo = dto.Solo;
        //    treinador.Wrestling = dto.Wrestling;
        //    treinador.FocoMental = dto.FocoMental;
        //    treinador.Defesa = dto.Defesa;
        //    treinador.LutaEmPe = dto.LutaEmPe;

        //    await _TreinadorRepository.AtualizarAsync(treinador);
        //}


    }

}
