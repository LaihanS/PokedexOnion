
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Services
{
    public class PokeService : IPokeService
    {
        private readonly IPokemonRepository repositorypoke;

        public PokeService(IPokemonRepository appliContext)
        {
            repositorypoke = appliContext;
        }

        public async Task AddAsyncPokemon(SavePokemonViewModel vm)
        {
            Pokemon pokemon = new();
            pokemon.idRegion = vm.idRegion;
            pokemon.subtipo = vm.subtipo;
            pokemon.idtipo = vm.idtipo;
            pokemon.name = vm.name;
            pokemon.ImagePath = vm.ImagePath;
            pokemon.description = vm.description;

            await repositorypoke.AddAsyncPokemon(pokemon);
        }

        public async Task Delete(SavePokemonViewModel vm)
        {
            int id = vm.idpoke;
            Pokemon pokemon = await repositorypoke.GetPokeByidAsync(id);
            await repositorypoke.DeleteAsync(pokemon);
        }
        public async Task EditAsyncPokemon(SavePokemonViewModel vm)
        {
            Pokemon pokemo = new();
            pokemo.idpoke = vm.idpoke;
            pokemo.idRegion = vm.idRegion;
            pokemo.subtipo = vm.subtipo;
            pokemo.idtipo = vm.idtipo;
            pokemo.name = vm.name;
            pokemo.ImagePath = vm.ImagePath;
            pokemo.description = vm.description;

            await repositorypoke.EditAsync(pokemo);
        }


        public async Task<List<PokemonViewModel>> GetPokemons()
        {
            var pokemonlist = await repositorypoke.GetPokeAsync();
            return pokemonlist.Select(pokemon => new PokemonViewModel
            {
                name = pokemon.name,
                description = pokemon.description,
                ImagePath = pokemon.ImagePath,
                idpoke = pokemon.idpoke,
                idRegion = pokemon.idRegion,
                idtipo = pokemon.idtipo,
                Region = pokemon.Region,
                Tipo = pokemon.Tipo,
                subtipo = pokemon.subtipo,
            }).ToList();
        }


        public async Task<List<PokemonViewModel>> GetPokemonsFiltro(FilterPokeViewModel filter)
        {
            var pokemonlist = await repositorypoke.GetPokeAsync();
            var pokemons = pokemonlist.Select(pokemon => new PokemonViewModel
            {
                name = pokemon.name,
                description = pokemon.description,
                ImagePath = pokemon.ImagePath,
                idpoke = pokemon.idpoke,
                idRegion = pokemon.idRegion,
                idtipo = pokemon.idtipo,
                Region = pokemon.Region,
                Tipo = pokemon.Tipo,
                subtipo = pokemon.subtipo,
            }).ToList();

            if (filter.RegionId != null)
            {
                pokemons = pokemons.Where(pokemon => pokemon.idRegion == filter.RegionId.Value).ToList();
            }
            else if (filter.RegionName != null)
            {
                pokemons = pokemons.Where(pokemon => pokemon.name == filter.RegionName).ToList();
            }

            return pokemons;
        }

        public async Task<SavePokemonViewModel> GetAsyncPoke(int id)
        {
            var pokemon = await repositorypoke.GetPokeByidAsync(id);

            SavePokemonViewModel pokevm = new();
            pokevm.idpoke = pokemon.idpoke;
            pokevm.idpoke = pokemon.idpoke;
            pokevm.idRegion = pokemon.idRegion;
            pokevm.idtipo = pokemon.idtipo;
            pokevm.ImagePath = pokemon.ImagePath;
            pokevm.name = pokemon.name;
            pokevm.description = pokemon.description;
            pokevm.subtipo = pokemon.subtipo;


            return pokevm;

        }

        public async Task<SavePokemonViewModel> GetEditAsyncPoke(int id)
        {

            var pokemon = await repositorypoke.GetPokeByidAsync(id);

            SavePokemonViewModel pokevm = new();
            pokevm.idpoke = pokemon.idpoke;
            pokevm.idRegion = pokemon.idRegion;
            pokevm.idtipo = pokemon.idtipo;
            pokevm.ImagePath = pokemon.ImagePath;
            pokevm.name = pokemon.name;
            pokevm.description = pokemon.description;
            pokevm.subtipo = pokemon.subtipo;

            return pokevm;

        }


    }
}
