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
        Task<Graduacao?> ObterPorIdAsync(long id);
        Task AddAsync(Graduacao graduacao);
        Task AtualizarAsync(Graduacao graduacao);
    }

}
