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
    public class TurmaRepository : ITurmaRepository
    {
        private readonly AppDbContext _context;

        public TurmaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Turma turma)
        {
            _context.Turma.Add(turma);
            await _context.SaveChangesAsync();
        }

        public async Task<Turma?> ListarPorId(long id)
            => await _context.Turma.FindAsync(id);

        public async Task AdicionarAsync(Turma turma)
        {
            await _context.Turma.AddAsync(turma);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Turma>> ListarTodasAsync()
        {
            return await _context.Turma.ToListAsync();
        }

        public async Task AtualizarAsync(Turma turma)
        {
            _context.Turma.Update(turma);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoverAsync(long id)
        {
            var turma = await _context.Turma.FindAsync(id);
            if (turma == null) return false;

            _context.Turma.Remove(turma);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task InativarAsync(long id)
        {
            var turma = await _context.Turma.FindAsync(id);

            turma.Inativar();
            await _context.SaveChangesAsync();

        }

    }

}
