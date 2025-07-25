﻿using FighterTrainer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FighterTrainer.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Atleta> Atletas => Set<Atleta>();
    public DbSet<Treinador> Treinadores => Set<Treinador>();
    public DbSet<FichaTreino> FichasTreino => Set<FichaTreino>();
    public DbSet<UsuarioModalidade> UsuarioModalidade { get; set; }
    public DbSet<Modalidade> Modalidade => Set<Modalidade>();
    public DbSet<Graduacao> Graduacao => Set<Graduacao>();
    public DbSet<Federacao> Federacao => Set<Federacao>();
    public DbSet<Cidade> Cidade => Set<Cidade>();
    public DbSet<Unidade> Unidade => Set<Unidade>();
    public DbSet<Turma> Turma => Set<Turma>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UsuarioModalidade>()
            .HasKey(um => new { um.UsuarioId, um.ModalidadeId });

        modelBuilder.Entity<UsuarioModalidade>()
            .HasOne(um => um.Usuario)
            .WithMany(u => u.Modalidades)
            .HasForeignKey(um => um.UsuarioId);

        modelBuilder.Entity<UsuarioModalidade>()
            .HasOne(um => um.Modalidade)
            .WithMany(m => m.Usuarios)
            .HasForeignKey(um => um.ModalidadeId);

        modelBuilder.Entity<UsuarioModalidade>()
            .HasOne(um => um.Graduacao)
            .WithMany()
            .HasForeignKey(um => um.GraduacaoId);
    }


}
