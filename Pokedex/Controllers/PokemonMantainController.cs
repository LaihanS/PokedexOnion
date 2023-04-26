
using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels;
using Pokedex.Infrastructure.Persistence.Contexts;

namespace Pokedex.Controllers
{
    public class PokemonMantainController : Controller
    {
        private readonly ITipoService _tipoService;
        private readonly IRegionService _regionService;
        private readonly IPokeService _pokeService;

        public PokemonMantainController(ITipoService tipo, IRegionService region, IPokeService pokemon )
        {
            _pokeService = pokemon;
            _regionService = region;
            _tipoService = tipo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _pokeService.GetPokemons());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Tipos = await _tipoService.GetTipos();
            ViewBag.Regions = await _regionService.GetRegiones();
            return View("SavePokemon", new SavePokemonViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Tipos = await _tipoService.GetTipos();
                ViewBag.Regions = await _regionService.GetRegiones();
                return View("SavePokemon", vm);
            }
            await _pokeService.AddAsyncPokemon(vm);

            return RedirectToRoute(new {controller = "PokemonMantain", action = "Index" });
        }


        public async Task<IActionResult> Edit(int id)
        {

            ViewBag.Tipos = await _tipoService.GetTipos();
            ViewBag.Regions = await _regionService.GetRegiones();
            return View("SavePokemon", await _pokeService.GetEditAsyncPoke(id));

        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Tipos = await _tipoService.GetTipos();
                ViewBag.Regions = await _regionService.GetRegiones();
                return View("Savepokemon", vm);
            }

            await _pokeService.EditAsyncPokemon(vm);
            return RedirectToRoute(new { controller = "PokemonMantain", action = "Index" });
        }

        public async Task<IActionResult> DeletePokemon(int id)
        {
           
            return View("DeletePokemon", await _pokeService.GetAsyncPoke(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostDeletePokemon(SavePokemonViewModel vm)
        {
           await _pokeService.Delete(vm);
            return RedirectToRoute(new { controller = "PokemonMantain", action = "Index" });
        }

    }
}
