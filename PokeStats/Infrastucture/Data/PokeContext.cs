using Microsoft.EntityFrameworkCore;
using Infrastructure.Models;

namespace Infrastructure.Data;

public class PokeContext : DbContext
{
    DbSet<Pokemon> Pokemons { get; set; }

    public PokeContext(DbContextOptions<PokeContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL();
        base.OnConfiguring(optionsBuilder);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pokemon>().HasKey(p => p.PokemonId);
        base.OnModelCreating(modelBuilder);
    }
}
