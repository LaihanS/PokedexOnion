using Pokedex.Core.Domain.Entities;

namespace Pokedex.Core.Application.Interfaces.Repositories
{
    public interface IRegionRepository
    {
        Task AddAsync(Region region);
        Task DeleteAsync(Region region);
        Task EditAsync(Region region);
        Task<List<Region>> GetRegiAsync();
        Task<Region?> GetRegiByidAsync(int id);
    }
}