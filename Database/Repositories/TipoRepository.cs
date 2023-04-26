
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Infrastructure.Persistence.Contexts;
using Pokedex.Core.Domain.Entities;
using Pokedex.Core.Application.Interfaces.Repositories;

namespace Pokedex.Infrastructure.Persistence.Repositories
{
    public class TipoRepository : ITipoRepository
    {
        private readonly AppliContext context;

        public TipoRepository(AppliContext context)
        {

            this.context = context;
        }

        public async Task AddAsync(Tipo tipo)
        {
            await context.Set<Tipo>().AddAsync(tipo);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(Tipo tipo)
        {
            context.Entry(tipo).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tipo tipo)
        {
            context.Set<Tipo>().Remove(tipo);
            await context.SaveChangesAsync();
        }

        public async Task<List<Tipo>> GetTipoAsync()
        {
            return await context.Set<Tipo>().ToListAsync();
        }

        public async Task<Tipo> GetTipoByidAsync(int id)
        {
            return await context.Set<Tipo>().FindAsync(id);
        }
    }
}
