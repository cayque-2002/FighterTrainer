using FighterTrainer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Interfaces;

public interface IPasswordHasher
{
    string Hash(string senha);
    bool Verificar(string senhaTexto, string hash);
}

