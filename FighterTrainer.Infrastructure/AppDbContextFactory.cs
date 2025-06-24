using FighterTrainer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FighterTrainer.Infrastructure;

//Aqui a connection string é direta no código, porque essa factory é usada só em tempo de design (migrations). Na execução normal, a aplicação usa o appsettings.json.

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=fightertrainer;Username=postgres;Password=dev123");

        return new AppDbContext(optionsBuilder.Options);
    }
}
