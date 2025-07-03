using FighterTrainer.Application.Interfaces;
using FighterTrainer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FighterTrainer.Infrastructure.Context;
using System;
using FighterTrainer.Domain.Interfaces;

namespace FighterTrainer.Application.Services;

public class FederacaoRepository : IFederacaoRepository
{
    private readonly AppDbContext _context;

    public FederacaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Federacao>> GetAllAsync()
    {
        return await _context.Federacao.ToListAsync();
    }
    public async Task<Federacao?> ObterPorIdAsync(long id)
    {
        return await _context.Federacao.FindAsync(id);
    }

    public async Task AddAsync(Federacao federacao)
    {
        _context.Federacao.Add(federacao);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Federacao federacao)
    {
        _context.Federacao.Update(federacao);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> RemoverAsync(long id)
    {
        var federacao = await _context.Federacao.FindAsync(id);
        if (federacao == null)
        {
            return false;
        }
        else
        {
            _context.Federacao.Remove(federacao);
            await _context.SaveChangesAsync();
            return true;
        }

    }

}

