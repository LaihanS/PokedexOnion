using Pokedex.Core.Domain.Entities;

namespace Pokedex.Core.Application.Interfaces.Repositories
{
    public interface ITipoRepository
    {
        Task AddAsync(Tipo tipo);
        Task DeleteAsync(Tipo tipo);
        Task EditAsync(Tipo tipo);
        Task<List<Tipo>> GetTipoAsync();
        Task<Tipo> GetTipoByidAsync(int id);
    }
}