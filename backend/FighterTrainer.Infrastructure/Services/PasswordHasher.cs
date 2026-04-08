using FighterTrainer.Domain.Interfaces;
using BCrypt.Net;

namespace FighterTrainer.Infrastructure.Services;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string senha)
    {
        return BCrypt.Net.BCrypt.HashPassword(senha);
    }

    public bool Verificar(string senhaTexto, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(senhaTexto, hash);
    }
}
