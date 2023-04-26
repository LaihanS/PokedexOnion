
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
    public class TipoService : ITipoService
    {
        private readonly ITipoRepository repository;
        public TipoService(ITipoRepository appliContext)
        {

            repository = appliContext;
        }

        public async Task AddAsyncTipo(SaveTipoViewModel vm)
        {
            Tipo tipo = new();
            tipo.tipoName = vm.tipoName;
            tipo.ImagePath = vm.ImagePath;
            await repository.AddAsync(tipo);
        }


        public async Task<List<TipoViewModel>> GetTipos()
        {
            var tipolist = await repository.GetTipoAsync();
            return tipolist.Select(tipo => new TipoViewModel
            {
                idtipo = tipo.idtipo,
                tipoName = tipo.tipoName,
                ImagePath = tipo.ImagePath,

            }).ToList();
        }

        public async Task<SaveTipoViewModel> GetEditAsyncTipo(int id)
        {

            var tipo = await repository.GetTipoByidAsync(id);

            SaveTipoViewModel saveTipoView = new();

            saveTipoView.idtipo = tipo.idtipo;
            saveTipoView.ImagePath = tipo.ImagePath;
            saveTipoView.tipoName = tipo.tipoName;

            return saveTipoView;

        }

        public async Task Delete(SaveTipoViewModel vm)
        {
            int id = vm.idtipo;
            Tipo tipo = await repository.GetTipoByidAsync(id);
            await repository.DeleteAsync(tipo);
        }

        public async Task EditAsynctipo(SaveTipoViewModel vm)
        {
            Tipo tipos = new();
            tipos.idtipo = vm.idtipo;
            tipos.tipoName = vm.tipoName;
            tipos.ImagePath = vm.ImagePath;

            await repository.EditAsync(tipos);
        }


    }


}
