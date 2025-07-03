using FighterTrainer.Application.Interfaces;
using FighterTrainer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FighterTrainer.Infrastructure.Context;
using System;
using FighterTrainer.Domain.Interfaces;

namespace FighterTrainer.Application.Services;

public class GraduacaoRepository : IGraduacaoRepository
{
    private readonly AppDbContext _context;
     
    public GraduacaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Graduacao>> GetAllAsync()
    {
        return await _context.Graduacao.ToListAsync();
    }
    public async Task<Graduacao?> ObterPorIdAsync(long id)
    {
        return await _context.Graduacao.FindAsync(id);
    }

    public async Task AddAsync(Graduacao graduacao)
    {
        _context.Graduacao.Add(graduacao);
        await _context.SaveChangesAsync();
    }
    public async Task AtualizarAsync(Graduacao graduacao)
    {
        _context.Graduacao.Update(graduacao);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> RemoverAsync(long id)
    {
        var graduacao = await _context.Graduacao.FindAsync(id);
        if (graduacao == null)
        {
            return false;
        }
        else
        {
            _context.Graduacao.Remove(graduacao);
            await _context.SaveChangesAsync();
            return true;
        }

    }

}

