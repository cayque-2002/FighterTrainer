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

            // UsuarioModalidade
            modelBuilder.Entity<UsuarioModalidade>(entity =>
            {
                entity.ToTable("usuariomodalidade");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.UsuarioId)
                      .HasColumnName("usuarioid");

                entity.Property(e => e.ModalidadeId)
                      .HasColumnName("modalidadeid");

                entity.Property(e => e.GraduacaoId)
                      .HasColumnName("graduacaoid");

                entity.Property(e => e.DataInicio)
                      .HasColumnName("datainicio");

                entity.Property(e => e.Ativo)
                      .HasColumnName("ativo");

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

            // Atletas
            modelBuilder.Entity<Atleta>(entity =>
            {
                entity.ToTable("atletas");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.UsuarioId)
                      .HasColumnName("usuarioid");

                entity.Property(e => e.Peso)
                      .HasColumnName("peso");

                entity.Property(e => e.Altura)
                      .HasColumnName("altura");

                entity.Property(e => e.Apelido)
                      .HasColumnName("apelido");

                entity.Property(e => e.Resistencia)
                      .HasColumnName("resistencia");

                entity.Property(e => e.Agilidade)
                      .HasColumnName("agilidade");

                entity.Property(e => e.Solo)
                      .HasColumnName("solo");

                entity.Property(e => e.Wrestling)
                      .HasColumnName("wrestling");

                entity.Property(e => e.FocoMental)
                      .HasColumnName("focomental");

                entity.Property(e => e.Defesa)
                      .HasColumnName("defesa");

                entity.Property(e => e.LutaEmPe)
                      .HasColumnName("lutaempe");

                entity.Property(e => e.DataCadastro)
                      .HasColumnName("datacadastro");
            });

            // Treinadores
            modelBuilder.Entity<Treinador>(entity =>
            {
                entity.ToTable("treinadores");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.UsuarioId)
                      .HasColumnName("usuarioid");

                entity.Property(e => e.DataCadastro)
                      .HasColumnName("datacadastro");

                entity.HasOne(e => e.Usuario)
                      .WithMany()
                      .HasForeignKey(e => e.UsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // FichasTreino
            modelBuilder.Entity<FichaTreino>(entity =>
            {
                entity.ToTable("fichastreino");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.AtletaId)
                      .HasColumnName("atletaid");

                entity.Property(e => e.TurmaId)
                      .HasColumnName("turmaid");

                entity.Property(e => e.UsuarioModalidadeId)
                      .HasColumnName("usuariomodalidadeid");

                entity.Property(e => e.Nivel)
                      .HasColumnName("nivel");

                entity.Property(e => e.Descricao)
                      .HasColumnName("descricao");

                entity.Property(e => e.DataCriacao)
                      .HasColumnName("datacriacao");

                entity.HasOne(e => e.Turma)
                      .WithMany()
                      .HasForeignKey(e => e.TurmaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Modalidade
            modelBuilder.Entity<Modalidade>(entity =>
            {
                entity.ToTable("modalidade");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Descricao)
                      .HasColumnName("descricao")
                      .IsRequired();

                entity.Property(e => e.DataCadastro)
                      .HasColumnName("datacadastro");
            });

            // Graduacao
            modelBuilder.Entity<Graduacao>(entity =>
            {
                entity.ToTable("graduacao");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.ModalidadeId)
                      .HasColumnName("modalidadeid");

                entity.Property(e => e.Descricao)
                      .HasColumnName("descricao")
                      .IsRequired();

                entity.Property(e => e.Nivel)
                      .HasColumnName("nivel");

                entity.Property(e => e.Grau)
                      .HasColumnName("grau");

                entity.Property(e => e.FederacaoId)
                      .HasColumnName("federacaoid");

                entity.Property(e => e.DataCadastro)
                      .HasColumnName("datacadastro");

                entity.HasOne(e => e.Federacao)
                      .WithMany()
                      .HasForeignKey(e => e.FederacaoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Federacao
            modelBuilder.Entity<Federacao>(entity =>
            {
                entity.ToTable("federacao");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Descricao)
                      .HasColumnName("descricao")
                      .IsRequired();

                entity.Property(e => e.DataCadastro)
                      .HasColumnName("datacadastro");
            });

            // Cidade
            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.ToTable("cidade");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Nome)
                      .HasColumnName("nome")
                      .IsRequired();

                entity.Property(e => e.UF)
                      .HasColumnName("uf")
                      .IsRequired();
            });

            // Unidade
            modelBuilder.Entity<Unidade>(entity =>
            {
                entity.ToTable("unidade");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Descricao)
                      .HasColumnName("descricao")
                      .IsRequired();

                entity.Property(e => e.CidadeId)
                      .HasColumnName("cidadeid");

                entity.Property(e => e.DataCriacao)
                      .HasColumnName("datacriacao");

                entity.Property(e => e.Ativo)
                      .HasColumnName("ativo");

                entity.HasOne(e => e.Cidade)
                      .WithMany()
                      .HasForeignKey(e => e.CidadeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Turma
            modelBuilder.Entity<Turma>(entity =>
            {
                entity.ToTable("turma");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Descricao)
                      .HasColumnName("descricao")
                      .IsRequired();

                entity.Property(e => e.UnidadeId)
                      .HasColumnName("unidadeid");

                entity.Property(e => e.HoraInicioAula)
                      .HasColumnName("horainicioaula")
                      .HasColumnType("time");

                entity.Property(e => e.HoraFimAula)
                      .HasColumnName("horafimaula")
                      .HasColumnType("time");

                entity.Property(e => e.TreinadorResponsavelId)
                      .HasColumnName("treinadorresponsavelid");

                entity.Property(e => e.DataCriacao)
                      .HasColumnName("datacriacao");

                entity.Property(e => e.Ativo)
                      .HasColumnName("ativo");

                entity.Property(e => e.LimiteAlunos)
                      .HasColumnName("limitealunos");

                entity.Property(e => e.ModalidadeId)
                      .HasColumnName("modalidadeid");

                entity.HasOne(e => e.Unidade)
                      .WithMany()
                      .HasForeignKey(e => e.UnidadeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Treinador)
                      .WithMany()
                      .HasForeignKey(e => e.TreinadorResponsavelId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Modalidade)
                      .WithMany()
                      .HasForeignKey(e => e.ModalidadeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            //Usuarios
            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id")
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
                      .HasColumnName("tipousuario")
                      .IsRequired();

                entity.Property(e => e.Ativo)
                      .HasColumnName("ativo")
                      .IsRequired();

                entity.Property(e => e.DataCadastro)
                      .HasColumnName("datacadastro")
                      .IsRequired();

                entity.Property(e => e.DataCadastro)
                      .HasColumnName("datacadastro");

            });

    }

}
