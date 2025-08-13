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
    public ICollection<UsuarioModalidade> Modalidades { get; set; } = new List<UsuarioModalidade>();
    public bool Ativo {  get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;


    protected Usuario() { }

    public Usuario(string nome, string email, string senhaHash, TipoUsuario tipoUsuario)
    {
        Nome = nome;
        Email = email;
        SenhaHash = BCrypt.Net.BCrypt.HashPassword(senhaHash); 
        TipoUsuario = tipoUsuario;
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

    public void Inativar() => Ativo = false;

}
