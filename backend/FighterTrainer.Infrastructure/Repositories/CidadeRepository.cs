using FighterTrainer.Application.Interfaces;
using FighterTrainer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FighterTrainer.Infrastructure.Context;
using System;
using FighterTrainer.Domain.Interfaces;

namespace FighterTrainer.Infrastructure.Repositories;

public class CidadeRepository : ICidadeRepository
{
    private readonly AppDbContext _context;
     
    public CidadeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cidade>> GetAllAsync()
    {
        return await _context.Cidade.ToListAsync();
    }
    public async Task<Cidade?> ObterPorIdAsync(long id)
    {
        return await _context.Cidade.FindAsync(id);
    }

}

