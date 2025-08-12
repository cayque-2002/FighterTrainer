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
    public class AtletaRepository : IAtletaRepository
    {
        private readonly AppDbContext _context;

        public AtletaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Atleta atleta)
        {
            _context.Atletas.Add(atleta);
            await _context.SaveChangesAsync();
        }

        public async Task<Atleta?> ListarPorId(long id)
            => await _context.Atletas.FindAsync(id);

        public async Task AdicionarAsync(Atleta atleta)
        {
            await _context.Atletas.AddAsync(atleta);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Atleta>> ListarTodasAsync()
        {
            return await _context.Atletas.ToListAsync();
        }

        public async Task AtualizarAsync(Atleta atleta)
        {
            _context.Atletas.Update(atleta);
            await _context.SaveChangesAsync();
        }

    }

}
