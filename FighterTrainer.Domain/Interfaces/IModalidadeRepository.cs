using FighterTrainer.Domain.Entities;

public interface IModalidadeRepository
{
    Task<List<Modalidade>> GetAllAsync();
    Task<Modalidade?> ObterPorIdAsync(long id);
    Task AddAsync(Modalidade modalidade);
    Task AtualizarAsync(Modalidade modalidade);
    Task<bool> RemoverAsync(long id);
}
