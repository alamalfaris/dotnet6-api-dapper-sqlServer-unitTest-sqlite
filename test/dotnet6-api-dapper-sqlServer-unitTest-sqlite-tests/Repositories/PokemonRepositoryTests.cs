using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Databases;
using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Entities;
using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Interfaces;
using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Repositories;
using FluentAssertions;

namespace dotnet6_api_dapper_sqlServer_unitTest_sqlite_tests.Repositories
{
    public class PokemonRepositoryTests
    {
        private readonly DatabaseContext _context;
        private readonly IPokemonRepository _repository;
        public PokemonRepositoryTests()
        {
            _context = new DatabaseContext(true);
            _repository = new PokemonRepository(_context, true);
        }

        [Fact]
        public void GetPokemons_ReturnEnumerablePokemon()
        {
            // Act
            var result = _repository.GetPokemons().GetAwaiter().GetResult();

            // Assert
            result.Should().BeOfType<List<Pokemon>>();
        }

        [Fact]
        public void InsertPokemon_NotThrowException()
        {
            // Arrange
            var pokemon = new Pokemon()
            {
                Id = 0,
                Name = "Pikachu",
                BirthDate = DateTime.Now
            };

            // Act
            var result = () => _repository.InsertPokemon(pokemon);

            // Assert
            result.Should().NotThrowAsync();
        }
    }
}
