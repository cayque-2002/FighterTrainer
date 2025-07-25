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
    public class UnidadeRepository : IUnidadeRepository
    {
        private readonly AppDbContext _context;

        public UnidadeRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Unidade?> ListarPorId(long id)
            => await _context.Unidade.FindAsync(id);

        public async Task AdicionarAsync(Unidade Unidade)
        {
            await _context.Unidade.AddAsync(Unidade);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Unidade>> ListarTodasAsync()
        {
            return await _context.Unidade.ToListAsync();
        }

        public async Task AtualizarAsync(Unidade Unidade)
        {
            _context.Unidade.Update(Unidade);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoverAsync(long id)
        {
            var Unidade = await _context.Unidade.FindAsync(id);
            if (Unidade == null) return false;

            _context.Unidade.Remove(Unidade);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task InativarAsync(long id)
        {
            var Unidade = await _context.Unidade.FindAsync(id);

            Unidade.Inativar();
            await _context.SaveChangesAsync();

        }

    }

}
