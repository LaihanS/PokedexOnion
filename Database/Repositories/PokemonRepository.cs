
using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Domain.Entities;
using Pokedex.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly AppliContext context;

        public PokemonRepository(AppliContext context)
        {

            this.context = context;
        }

        public async Task AddAsyncPokemon(Pokemon pokemon)
        {
            await context.Set<Pokemon>().AddAsync(pokemon);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(Pokemon pokemon)
        {
            context.Entry(pokemon).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pokemon pokemon)
        {
            context.Set<Pokemon>().Remove(pokemon);
            await context.SaveChangesAsync();
        }

        public async Task<List<Pokemon>> GetPokeAsync()
        {
            return await context.Set<Pokemon>().Include(poke => poke.Region).Include(poke => poke.Tipo).ToListAsync();
        }

        public async Task<Pokemon> GetPokeByidAsync(int id)
        {
            return await context.Set<Pokemon>().FindAsync(id);
        }

    }
}
