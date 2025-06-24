using FighterTrainer.Domain.Entities;
using FighterTrainer.Domain.Interfaces;
using FighterTrainer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FighterTrainer.Infrastructure.Repositories;

public class UsuarioModalidadeRepository : IUsuarioModalidadeRepository
{
    private readonly AppDbContext _context;

    public UsuarioModalidadeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(UsuarioModalidade usuarioModalidade)
    {
        await _context.UsuarioModalidade.AddAsync(usuarioModalidade);
        await _context.SaveChangesAsync();
    }

    public async Task<List<UsuarioModalidade>> ObterPorUsuarioIdAsync(long usuarioId)
    {
        return await _context.UsuarioModalidade
            .Include(um => um.Modalidade)
            .Include(um => um.Graduacao)
            .Where(um => um.UsuarioId == usuarioId)
            .ToListAsync();
    }
}
