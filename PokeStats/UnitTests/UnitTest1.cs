using Infrastructure.Data;
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
    }
}