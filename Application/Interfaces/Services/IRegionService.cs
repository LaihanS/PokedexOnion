using Pokedex.Core.Application.ViewModels;

namespace Pokedex.Core.Application.Interfaces.Services
{
    public interface IRegionService
    {
        Task AddAsyncRegion(SaveRegionViewModel vm);
        Task Delete(SaveRegionViewModel vm);
        Task EditAsyncRegion(SaveRegionViewModel vm);
        Task<SaveRegionViewModel> GetEditAsyncRegion(int id);
        Task<List<RegionViewModel>> GetRegiones();
    }
}