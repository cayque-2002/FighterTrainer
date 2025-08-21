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
            //.Include(um => um.ModalidadeId)
            //.Include(um => um.GraduacaoId)
            //.Include(um => um.DataInicio)
            //.Include(um => um.Ativo)
            .Where(um => um.UsuarioId == usuarioId)
            .ToListAsync();
    }

    public async Task<List<UsuarioModalidade>> ObterPorIdAsync(long id)
    {
        return await _context.UsuarioModalidade
            .Where(um => um.Id == id)
            .ToListAsync();
    }

    public async Task InativarAsync(long id)
    {
        var usuarioModalidade =  _context.UsuarioModalidade.Where(x=> x.Id == id).First();

        usuarioModalidade.Inativar();
        await _context.SaveChangesAsync();

    }

    public async Task AtivarAsync(long id)
    {
        var usuarioModalidade = _context.UsuarioModalidade.Where(x => x.Id == id).First();

        usuarioModalidade.Ativar();
        await _context.SaveChangesAsync();

    }
}
