using FighterTrainer.Application.Interfaces;
using FighterTrainer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FighterTrainer.Infrastructure.Context;
using System;

namespace FighterTrainer.Application.Services;

public class UsuarioModalidadeService : IUsuarioModalidadeService
{
    private readonly AppDbContext _context;

    public UsuarioModalidadeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(UsuarioModalidadeDto dto)
    {
        var entidade = new UsuarioModalidade(dto.UsuarioId, dto.ModalidadeId, dto.GraduacaoId)
        {
            DataInicio = dto.DataInicio == default ? DateTime.UtcNow : dto.DataInicio,
            Ativo = dto.Ativo
        };

        _context.UsuarioModalidade.Add(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<UsuarioModalidade>> ListarPorUsuario(long usuarioId)
    {
        return await _context.UsuarioModalidade
            .Include(x => x.Modalidade)
            .Include(x => x.Graduacao)
            .Where(x => x.UsuarioId == usuarioId && x.Ativo)
            .ToListAsync();
    }
}
