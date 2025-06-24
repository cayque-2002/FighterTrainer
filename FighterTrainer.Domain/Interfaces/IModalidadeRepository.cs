using FighterTrainer.Domain.Entities;

public interface IModalidadeRepository
{
    Task<IEnumerable<Modalidade>> GetAllAsync();
    Task<Modalidade?> GetByIdAsync(long id);
    Task AddAsync(Modalidade modalidade);
}
