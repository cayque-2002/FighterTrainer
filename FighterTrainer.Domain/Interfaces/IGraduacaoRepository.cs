using FighterTrainer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Interfaces
{
    public interface IGraduacaoRepository
    {
        Task<List<Graduacao>> GetAllAsync();
        Task AddAsync(Graduacao modalidade);
    }

}
