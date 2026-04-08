using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterTrainer.Application.Services;
using FighterTrainer.Domain.Entities;

namespace FighterTrainer.Application.Interfaces
{
    public interface IAtletaService
    {
        Task<AtletaDto> AdicionarAsync(AtletaDto atleta);
        Task<List<AtletaDto>> ListarTodasAsync();
        Task<AtletaDto> ListarPorId(long atletaId);
        Task AtualizarAsync(AtletaDto dto);
        Task<Atleta> ValidaAtleta(long atletaId);
        

    }

}
