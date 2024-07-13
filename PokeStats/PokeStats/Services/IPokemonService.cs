using Infrastructure.Models;

namespace PokeStats.Services;

public interface IPokemonService
{
    Task<List<Pokemon>> ReadDatabaseAsync();
}
