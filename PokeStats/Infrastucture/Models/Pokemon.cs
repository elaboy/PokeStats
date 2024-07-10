using Infrastructure.Enums;

namespace Infrastructure.Models;

public class Pokemon
{
    public int PokemonId { get; set; }
    public string Name { get; set; }
    public PokeType Type1 { get; set; }
    public PokeType Type2 { get; set; }
    public int Total { get; set; }
    public int HealthPoints { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int SpecialAttack { get; set; }
    public int SpecialDefense { get; set; }
    public int Speed { get; set; }
    public Generation Generation { get; set; }
}
