using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterTrainer.Application.Services;
using FighterTrainer.Domain.Entities;

namespace FighterTrainer.Application.Interfaces
{
    public interface ITreinadorService
    {
       // Task<TreinadorDto> AdicionarAsync(TreinadorDto treinador);
        Task<List<TreinadorDto>> ListarTodasAsync();
        Task<TreinadorDto> ListarPorId(long treinadorId);
       // Task AtualizarAsync(TreinadorDto dto);
        

    }

}
