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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObterPorEmailAsync(string email)
            => await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<Usuario?> ObterPorIdAsync(long id)
            => await _context.Usuarios.FindAsync(id);

        public async Task AdicionarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EmailJaCadastradoAsync(string email)
            => await _context.Usuarios.AnyAsync(u => u.Email == email);

        public async Task<List<Usuario>> ListarTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

    }

}
