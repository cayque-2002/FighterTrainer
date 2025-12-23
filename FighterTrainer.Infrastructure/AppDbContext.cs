using FighterTrainer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FighterTrainer.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Usuarios> Usuarios => Set<Usuarios>();
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

        modelBuilder.Entity<UsuarioModalidade>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasOne(e => e.Usuario)
                .WithMany(u => u.UsuarioModalidades)
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Modalidade)
                .WithMany()
                .HasForeignKey(e => e.ModalidadeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Graduacao)
                .WithMany()
                .HasForeignKey(e => e.GraduacaoId)
                .OnDelete(DeleteBehavior.Restrict);
        });


        modelBuilder.Entity<Turma>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            entity.HasOne(e => e.Unidade)
                .WithMany()
                .HasForeignKey(e => e.UnidadeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Treinador)
                .WithMany()
                .HasForeignKey(e => e.TreinadorResponsavelId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(e => e.HoraInicioAula)
                 .HasColumnType("time");

            entity.Property(e => e.HoraFimAula)
                  .HasColumnType("time");

            entity.HasOne(e => e.Modalidade)
                .WithMany()
                .HasForeignKey(e => e.ModalidadeId)
                .OnDelete(DeleteBehavior.Restrict);

        });

        modelBuilder.Entity<Treinador>(entity =>
        {
            entity.ToTable("treinadores");
            
            entity.Property(e => e.Id)
                  .HasColumnName("id") 
                  .ValueGeneratedOnAdd();

            entity.HasKey(e => e.Id);

            entity.Property(e => e.UsuarioId)
                  .HasColumnName("usuarioid")
                  .IsRequired();

            entity.Property(e => e.DataCadastro)
                  .HasColumnName("datacadastro")
                  .IsRequired();

            entity.HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

        });


        modelBuilder.Entity<FichaTreino>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

        });


        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.ToTable("usuarios"); // ajuste para o nome exato da tabela no seu BD

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                  .HasColumnName("id") // nome da coluna no BD
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.Nome)
                  .HasColumnName("nome")
                  .IsRequired();

            entity.Property(e => e.Email)
                  .HasColumnName("email")
                  .IsRequired();

            entity.Property(e => e.SenhaHash)
                  .HasColumnName("senhahash")
                  .IsRequired();

            entity.Property(e => e.TipoUsuario)
                  .HasColumnName("tipousuario");

            entity.Property(e => e.Ativo)
                  .HasColumnName("ativo");

            entity.Property(e => e.DataCadastro)
                  .HasColumnName("datacadastro");
        });

    }

}
