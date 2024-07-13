using Infrastructure.Enums;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;
using PokeStats.Models;
using PokeStats.Services;
using System.Diagnostics;

namespace PokeStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IPokemonService _pokemonService;

        public HomeController(ILogger<HomeController> logger , IPokemonRepository pokemonRepository , IPokemonService pokemonService)
        {
            _logger = logger;
            _pokemonRepository = pokemonRepository;
            _pokemonService = pokemonService;
        }

        public async Task<IActionResult> Index()
        {
            var pokemons = await _pokemonRepository.GetAllPokemons();
            return View(pokemons);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
