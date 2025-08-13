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
    public class FichaTreinoRepository : IFichaTreinoRepository
    {
        private readonly AppDbContext _context;

        public FichaTreinoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FichaTreino fichaTreino)
        {
            _context.FichasTreino.Add(fichaTreino);
            await _context.SaveChangesAsync();
        }

        public async Task<FichaTreino?> ListarPorId(long id)
            => await _context.FichasTreino.FindAsync(id);

        public async Task AdicionarAsync(FichaTreino fichaTreino)
        {
            await _context.FichasTreino.AddAsync(fichaTreino);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FichaTreino>> ListarTodasAsync()
        {
            return await _context.FichasTreino.ToListAsync();
        }

        public async Task AtualizarAsync(FichaTreino fichaTreino)
        {
            _context.FichasTreino.Update(fichaTreino);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FichaTreino>> ListarAlunosPorTurmaAsync(long turmaId)
        {
            return await _context.FichasTreino.Where(x => x.TurmaId == turmaId).ToListAsync();
        }

        public async Task<List<FichaTreino>> ListarTreinosPorAtleta(long atletaId)
        {
            return await _context.FichasTreino.Where(x => x.AtletaId == atletaId).ToListAsync();
        }

    }

}
