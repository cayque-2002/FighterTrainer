using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTrainer.Domain.Exceptions
{
    // Base genérica
    public class DomainException : Exception
    {
        public DomainException(string mensagem) : base(mensagem) { }
    }

    // Quando não encontra o recurso
    public class NotFoundException : DomainException
    {
        public NotFoundException(string mensagem) : base(mensagem) { }
    }

    // Quando já existe um vínculo, duplicação, etc
    public class BusinessRuleException : DomainException
    {
        public BusinessRuleException(string mensagem) : base(mensagem) { }
    }

    // Quando usuário não tem permissão
    public class UnauthorizedException : DomainException
    {
        public UnauthorizedException(string mensagem) : base(mensagem) { }
    }
}
