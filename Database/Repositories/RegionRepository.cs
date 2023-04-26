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
    public class RegionRepository : IRegionRepository
    {
        private readonly AppliContext context;

        public RegionRepository(AppliContext context)
        {

            this.context = context;
        }

        public async Task AddAsync(Region region)
        {
            await context.Set<Region>().AddAsync(region);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(Region region)
        {
            context.Entry(region).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Region region)
        {
            context.Set<Region>().Remove(region);
            await context.SaveChangesAsync();
        }

        public async Task<List<Region>> GetRegiAsync()
        {
            return await context.Set<Region>().ToListAsync();
        }

        public async Task<Region?> GetRegiByidAsync(int id)
        {
            return await context.Set<Region>().FindAsync(id);
        }
    }
}
