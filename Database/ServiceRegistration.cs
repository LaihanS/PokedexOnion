using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Infrastructure.Persistence.Contexts;
using Pokedex.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pokedex.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        //El primer parámetro representa a quien se extiende,
        //y el segundo en adelante el dato que se recibe
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<AppliContext>(o => o.UseInMemoryDatabase("PokedexDB"));
            }
            else
            {

                var connectionString = configuration.GetConnectionString("ConnectionDefault");
              services.AddDbContext<AppliContext>(options => options.UseSqlServer(connectionString, 
                  m => m.MigrationsAssembly(typeof(AppliContext).Assembly.FullName)));
            }
            #endregion

            #region repositories
            services.AddTransient<IPokemonRepository, PokemonRepository>();
            services.AddTransient<ITipoRepository, TipoRepository>();
            services.AddTransient<IRegionRepository, RegionRepository>();
            #endregion
        }
    }
}
