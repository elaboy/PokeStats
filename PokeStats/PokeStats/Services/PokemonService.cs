using Infrastructure.Enums;
using Infrastructure.Models;
using PokeStats.Services;

public class PokemonService : IPokemonService
{
    public async Task<List<Pokemon>> ReadDatabaseAsync()
    {
        var path = @"wwwroot\media\pokemon.csv";
        var readCsv = await File.ReadAllLinesAsync(path);

        var pokemonList = new List<Pokemon>();
        foreach (var line in readCsv.Skip(1))
        {
            var item = line.Split(',');
            pokemonList.Add(new Pokemon
            {
                PokedexId = int.Parse(item[0]),
                Name = item[1],
                Type1 = Enum.Parse<PokeType>(item[2], true),
                Type2 = string.IsNullOrEmpty(item[3]) ? PokeType.None : Enum.Parse<PokeType>(item[3], true),
                Total = int.Parse(item[4]),
                HealthPoints = int.Parse(item[5]),
                Attack = int.Parse(item[6]),
                Defense = int.Parse(item[7]),
                SpecialAttack = int.Parse(item[8]),
                SpecialDefense = int.Parse(item[9]),
                Speed = int.Parse(item[10]),
                Generation = (Generation)int.Parse(item[11]),
                Legendary = bool.Parse(item[12].ToLower())
            });
        }

        return pokemonList;
    }
}
