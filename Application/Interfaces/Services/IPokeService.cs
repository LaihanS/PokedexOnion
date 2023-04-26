using Pokedex.Core.Application.ViewModels;

namespace Pokedex.Core.Application.Interfaces.Services
{
    public interface IPokeService
    {
        Task AddAsyncPokemon(SavePokemonViewModel vm);
        Task Delete(SavePokemonViewModel vm);
        Task EditAsyncPokemon(SavePokemonViewModel vm);
        Task<SavePokemonViewModel> GetAsyncPoke(int id);
        Task<SavePokemonViewModel> GetEditAsyncPoke(int id);
        Task<List<PokemonViewModel>> GetPokemons();
        Task<List<PokemonViewModel>> GetPokemonsFiltro(FilterPokeViewModel filter);
    }
}