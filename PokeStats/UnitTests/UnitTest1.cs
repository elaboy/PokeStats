using Infrastructure.Data;
using Infrastructure.Enums;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var pokeContext = new Infrastructure.Data.PokeContext(new DbContextOptions<PokeContext>());
            Assert.That(pokeContext.Database.CanConnect());
        }

        [Test]
        public void ReadDatabaseTest()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Files", "pokemon.csv");
            var readCsv = File.ReadAllLines(path).Skip(1);

            var pokemonList = new List<Pokemon>();

            foreach (var line in readCsv)
            {
                var item = line.Split(',');
                pokemonList.Add(new Pokemon
                {
                    PokedexId = int.Parse(item[0]),
                    Name = item[1],
                    Type1 = Enum.Parse<PokeType>(item[2], true),
                    Type2 = item[3] == "" ? PokeType.None : Enum.Parse<PokeType>(item[2], true),
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

            Assert.That(pokemonList.Count(), Is.EqualTo(800));
        }
    }
}