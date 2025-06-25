using FighterTrainer.Domain.Entities;

public interface IModalidadeRepository
{
    Task<List<Modalidade>> GetAllAsync();
    Task AddAsync(Modalidade modalidade);
}
