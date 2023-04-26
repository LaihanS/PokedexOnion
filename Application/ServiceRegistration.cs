using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddapplicationLayer(this IServiceCollection services)
        {
            #region repositories
            services.AddTransient<IPokeService, PokeService>();
            services.AddTransient<ITipoService, TipoService>();
            services.AddTransient<IRegionService, RegionService>();
            #endregion
        }
    }
}
