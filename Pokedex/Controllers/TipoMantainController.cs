
using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels;
using Pokedex.Infrastructure.Persistence.Contexts;

namespace Pokedex.Controllers
{
    public class TipoMantainController : Controller
    {
        private readonly ITipoService _service;
        public TipoMantainController(ITipoService tipoService) {

         _service = tipoService;

        }

        public async Task<IActionResult> Index()
        {
            return View( await _service.GetTipos());
        }

        public async Task<IActionResult> CreateTipo()
        {
            return View("SaveTipos", new SaveTipoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTipo(SaveTipoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipos", vm);
            }

            await _service.AddAsyncTipo(vm);
            return RedirectToRoute(new {controller = "TipoMantain", action = "Index"});
        }


        public async Task<IActionResult> DeleteTipo(int id)
        {
            return View("DeleteTipos", await _service.GetEditAsyncTipo(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostDeleteTipo(SaveTipoViewModel vm)
        {
            await _service.Delete(vm);
            return RedirectToRoute(new { controller = "TipoMantain", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveTipos", await _service.GetEditAsyncTipo(id));

        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveTipoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipos", vm);
            }

            await _service.EditAsynctipo(vm);
            return RedirectToRoute(new { controller = "TipoMantain", action = "Index" });
        }

    }
}
