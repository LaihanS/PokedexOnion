
using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels;
using Pokedex.Infrastructure.Persistence.Contexts;

namespace Pokedex.Controllers
{
    public class RegionMantainController : Controller
    {

        private readonly IRegionService service;
        public RegionMantainController(IRegionService region)
        {

            service = region;

        }

        public async Task<IActionResult> Index()
        {
            return View(await service.GetRegiones());
        }

        public async Task<IActionResult> CreateRegion()
        {
            return View("SaveRegion", new SaveRegionViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegion(SaveRegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }

            await service.AddAsyncRegion(vm);
            return RedirectToRoute(new { controller = "RegionMantain", action = "Index" });
        }


        public async Task<IActionResult> DeleteRegion(int id)
        {
            return View("DeleteRegion", await service.GetEditAsyncRegion(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostDeleteRegion(SaveRegionViewModel vm)
        {
            await service.Delete(vm);
            return RedirectToRoute(new { controller = "RegionMantain", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveRegion", await service.GetEditAsyncRegion(id));

        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveRegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }

            await service.EditAsyncRegion(vm);
            return RedirectToRoute(new { controller = "RegionMantain", action = "Index" });
        }

    }
}
