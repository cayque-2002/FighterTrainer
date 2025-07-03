using FighterTrainer.Application.Interfaces;
using FighterTrainer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FighterTrainer.Infrastructure.Context;
using System;

namespace FighterTrainer.Application.Services;

public class ModalidadeRepository : IModalidadeRepository
{
    private readonly AppDbContext _context;

    public ModalidadeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Modalidade>> GetAllAsync()
    {
        return await _context.Modalidade.ToListAsync();
    }

    public async Task<Modalidade?> ObterPorIdAsync(long id)
    {
        return await _context.Modalidade.FindAsync(id);
    }

    public async Task AddAsync(Modalidade modalidade)
    {
        _context.Modalidade.Add(modalidade);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Modalidade modalidade)
    {
        _context.Modalidade.Update(modalidade);
        await _context.SaveChangesAsync();
    }


    public async Task<bool> RemoverAsync(long id)
    {
        var modalidade = await _context.Modalidade.FindAsync(id);
        if (modalidade == null)
        {
          return false;
        }
        else 
        {
          _context.Modalidade.Remove(modalidade);
          await _context.SaveChangesAsync();
          return true;
        }
        
    }

}

