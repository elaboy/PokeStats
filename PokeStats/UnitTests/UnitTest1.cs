using Infrastructure.Data;
using Infrastructure.Enums;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Frameworks;
using NUnit.Framework.Constraints;

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
        public void CSVHelperTest()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files", "pokemon.csv");
            var readCsv = File.ReadAllLines(path);

            foreach (var line in readCsv)
            {
                var item = line.Split(',');
                var pokemon = new Pokemon
                {
                    PokemonId = int.Parse(item[0]),
                    Name = item[1],
                    Type1 = int.Parse(item[1]),
                    Type2 = item[3],
                    Total = int.Parse(item[4]),
                    HealthPoints = int.Parse(item[5]),
                    Attack = int.Parse(item[6]),
                    Defense = int.Parse(item[7]),
                    SpecialAttack = int.Parse(item[8]),
                    SpecialDefense = int.Parse(item[9]),
                    Speed = int.Parse(item[10]),
                    Generation = int.Parse(item[11]),
                    Program = bool.Parse(item[12])
                };  
            }
        }
    }
}