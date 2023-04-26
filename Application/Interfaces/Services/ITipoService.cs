using Pokedex.Core.Application.ViewModels;

namespace Pokedex.Core.Application.Interfaces.Services
{
    public interface ITipoService
    {
        Task AddAsyncTipo(SaveTipoViewModel vm);
        Task Delete(SaveTipoViewModel vm);
        Task EditAsynctipo(SaveTipoViewModel vm);
        Task<SaveTipoViewModel> GetEditAsyncTipo(int id);
        Task<List<TipoViewModel>> GetTipos();
    }
}