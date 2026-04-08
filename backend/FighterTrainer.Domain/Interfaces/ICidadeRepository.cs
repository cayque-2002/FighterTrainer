using FighterTrainer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Interfaces
{
    public interface ICidadeRepository
    {
        Task<List<Cidade>> GetAllAsync();
        Task<Cidade?> ObterPorIdAsync(long id);
       
    }

}
