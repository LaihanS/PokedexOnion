using Pokedex.Core.Domain.Entities;

namespace Pokedex.Core.Application.Interfaces.Repositories

{
    public interface IPokemonRepository
    {
        Task AddAsyncPokemon(Pokemon pokemon);
        Task DeleteAsync(Pokemon pokemon);
        Task EditAsync(Pokemon pokemon);
        Task<List<Pokemon>> GetPokeAsync();
        Task<Pokemon> GetPokeByidAsync(int id);
    }
}