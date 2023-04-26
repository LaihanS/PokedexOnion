
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
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository repository;
        public RegionService(IRegionRepository appliContext)
        {

            repository = appliContext;
        }


        public async Task AddAsyncRegion(SaveRegionViewModel vm)
        {
            Region region = new();
            region.regionName = vm.regionName;
            region.ImagePath = vm.ImagePath;
            await repository.AddAsync(region);
        }


        public async Task<List<RegionViewModel>> GetRegiones()
        {
            var region = await repository.GetRegiAsync();
            return region.Select(region => new RegionViewModel
            {
                idregion = region.idregion,
                regionName = region.regionName,
                ImagePath = region.ImagePath,

            }).ToList();
        }

        public async Task<SaveRegionViewModel> GetEditAsyncRegion(int id)
        {

            var region = await repository.GetRegiByidAsync(id);

            SaveRegionViewModel saveRegion = new();

            saveRegion.idregion = region.idregion;
            saveRegion.regionName = region.regionName;
            saveRegion.ImagePath = region.ImagePath;

            return saveRegion;

        }

        public async Task Delete(SaveRegionViewModel vm)
        {
            int id = vm.idregion;
            Region region = await repository.GetRegiByidAsync(id);
            await repository.DeleteAsync(region);
        }

        public async Task EditAsyncRegion(SaveRegionViewModel vm)
        {
            Region region = new();
            region.idregion = vm.idregion;
            region.regionName = vm.regionName;
            region.ImagePath = vm.ImagePath;

            await repository.EditAsync(region);
        }

    }


}
