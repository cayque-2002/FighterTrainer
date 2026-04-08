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
    public class TreinadorService : ITreinadorService
    {
        private readonly ITreinadorRepository _TreinadorRepository;


        public TreinadorService(
        ITreinadorRepository treinadorRepository)
        {
            _TreinadorRepository = treinadorRepository;
        }

        public async Task<TreinadorDto> ListarPorId(long id)
        {

            var treinador = await ValidaTreinador(id);
            
                return new TreinadorDto
                {
                    Id = treinador.Id,
                    UsuarioId = treinador.UsuarioId,
                };

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

        public async Task<Treinador> ValidaTreinador(long id)
        {
            var treinador = await _TreinadorRepository.ListarPorId(id);

            if (treinador == null)
            {
                throw new NotFoundException("Treinador não encontrado.");
            }

            return treinador;
            
        }

    }

}
