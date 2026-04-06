using FighterTrainer.Domain.Entities;
using FighterTrainer.Domain.Interfaces;
using FighterTrainer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Infrastructure.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        private readonly AppDbContext _context;

        public PresencaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Presenca presenca)
        {
            _context.Presencas.Add(presenca);
            await _context.SaveChangesAsync();
        }

        public async Task<Presenca?> ListarPorId(long id)
            => await _context.Presencas.FindAsync(id);

        public async Task AdicionarAsync(Presenca presenca)
        {
            await _context.Presencas.AddAsync(presenca);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Presenca>> ListarTodasAsync()
        {
            return await _context.Presencas.ToListAsync();
        }

        public async Task AtualizarAsync(Presenca presenca)
        {
            _context.Presencas.Update(presenca);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Presenca>> ListarPorTurmaId(long turmaId)
        {
            return await _context.Presencas.Where(x => x.TurmaId == turmaId).ToListAsync();
        }

        public async Task<List<Presenca>> ListarPorAtletaId(long atletaId)
        {
            return await _context.Presencas.Where(x => x.AtletaId == atletaId).ToListAsync();
        }

    }

}
