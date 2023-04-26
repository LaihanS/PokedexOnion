
using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.Services;
using Pokedex.Core.Application.ViewModels;
using Pokedex.Infrastructure.Persistence.Contexts;
using Pokedex.Models;
using System.Diagnostics;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPokeService _pokeService;
        private readonly IRegionService _regionService;
        public HomeController(IPokeService pokeService, IRegionService regionService )
        {
            _pokeService = pokeService;
            _regionService =regionService;
        }

        public async Task<IActionResult> Index(FilterPokeViewModel filter)
        {
            ViewBag.Regions = await _regionService.GetRegiones();
            return View(await _pokeService.GetPokemonsFiltro(filter));
        }
      
    }
}