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
    public class TreinadorRepository : ITreinadorRepository
    {
        private readonly AppDbContext _context;

        public TreinadorRepository(AppDbContext context)
        {
            _context = context;
        }

        //public async Task AddAsync(Treinador treinador)
        //{
        //    _context.Treinadores.Add(treinador);
        //    await _context.SaveChangesAsync();
        //}

        public async Task<Treinador?> 
            ListarPorId(long id)
            => await _context.Treinadores.FindAsync(id);

        //public async Task AdicionarAsync(Treinador treinador)
        //{
        //    await _context.Treinadores.AddAsync(treinador);
        //    await _context.SaveChangesAsync();
        //}

        public async Task<List<Treinador>> ListarTodasAsync()
        {
            return await _context.Treinadores.ToListAsync();
        }

        //public async Task AtualizarAsync(Treinador treinador)
        //{
        //    _context.Treinadores.Update(treinador);
        //    await _context.SaveChangesAsync();
        //}

    }

}
