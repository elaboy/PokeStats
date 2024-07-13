using Infrastructure.Enums;
using Infrastructure.Models;

namespace Infrastructure.Repository.Interfaces;

public interface IPokemonRepository
{
    Task<List<Pokemon>> GetAllPokemons();
    Task<Pokemon> GetPokemonByPokemonId(int pokemonId);
    Task<List<Pokemon>> GetPokemonByPokemonType(PokeType pokeType);
    Task<List<Pokemon>> GetLegedaryPokemons(bool legedary);
    Task<List<Pokemon>> GetPokemonsByPokedexId(int pokedexId);
    Task AddListPokemons(List<Pokemon> pokemons);
}
