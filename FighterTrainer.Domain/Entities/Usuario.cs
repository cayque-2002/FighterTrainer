using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FighterTrainer.Domain.Enums;

namespace FighterTrainer.Domain.Entities;

public class Usuario
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string SenhaHash { get; set; } = string.Empty;
    public TipoUsuario TipoUsuario { get; set; }
    public bool Ativo {  get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

    public ICollection<UsuarioModalidade> UsuarioModalidades { get; private set; } = new List<UsuarioModalidade>();


    public Usuario(string nome, string email, string senhaHash, TipoUsuario tipoUsuario, bool ativo)
    {
        Nome = nome;
        Email = email;
        SenhaHash = senhaHash; 
        TipoUsuario = tipoUsuario;
        Ativo = ativo;
    }

    public bool VerificarSenha(string senha) =>
       BCrypt.Net.BCrypt.Verify(senha, SenhaHash);

    public void AlterarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome inválido.");

        Nome = nome;
    }

    public void AlterarEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email inválido.");

        Email = email;
    }

    public void AlterarTipoUsuario(TipoUsuario tipo)
    {
        TipoUsuario = tipo;
    }
    public void AtualizarUsuario(Usuario usuario)
    {
        if (string.IsNullOrWhiteSpace(usuario.Email))
            throw new ArgumentException("Email inválido.");
        if (string.IsNullOrWhiteSpace(usuario.Nome))
            throw new ArgumentException("Nome inválido.");

        Nome = usuario.Nome;
        Email = usuario.Email;
        TipoUsuario = usuario.TipoUsuario;
        Ativo = usuario.Ativo;
    }



    public void Inativar() => Ativo = false;

}
