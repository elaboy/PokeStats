using Infrastructure.Data;
using Infrastructure.Enums;
using Infrastructure.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PokemonRepository : GenericRepository<PokemonRepository>, IPokemonRepository
{
    public PokemonRepository(PokeContext pokeContext) : base(pokeContext) { }

    public async Task<List<Pokemon>> GetAllPokemons()
    {
        return await _pokeContext.Pokemons.ToListAsync();
    }

    public async Task<Pokemon> GetPokemonByPokemonId(int pokemonId)
    {
        return await _pokeContext.Pokemons.Where(p => p.PokemonId == pokemonId).FirstOrDefaultAsync();
    }

    public async Task<List<Pokemon>> GetPokemonByPokemonType(PokeType pokeType)
    {
        return await _pokeContext.Pokemons.Where(p => p.Type1 == pokeType || p.Type2 == pokeType).ToListAsync();
    }

    public async Task<List<Pokemon>> GetLegedaryPokemons(bool legedary)
    {
        return await _pokeContext.Pokemons.Where(p => p.Legendary == legedary).ToListAsync();
    }

    public async Task<List<Pokemon>> GetPokemonsByPokedexId(int pokedexId)
    {
        return await _pokeContext.Pokemons.Where(p => p.PokedexId == pokedexId).ToListAsync();
    }

    public async Task AddListPokemons(List<Pokemon> pokemons)
    {
        _pokeContext.Pokemons.AddRange(pokemons);
        await _pokeContext.SaveChangesAsync();
    }
}
