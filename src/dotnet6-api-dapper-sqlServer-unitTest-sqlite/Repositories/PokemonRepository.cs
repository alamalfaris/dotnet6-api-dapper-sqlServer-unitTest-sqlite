using Dapper;
using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Databases;
using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Entities;
using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Interfaces;

namespace dotnet6_api_dapper_sqlServer_unitTest_sqlite.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DatabaseContext _context;
        private readonly bool _isUnitTest;

        public PokemonRepository(DatabaseContext context, bool isUnitTest = false)
        {
            _context = context;
            _isUnitTest = isUnitTest;
        }

        public async Task<IEnumerable<Pokemon>> GetPokemons()
        {
            using (var connection = _context.CreateConnection(_isUnitTest))
            {
                string sql = $@"SELECT * FROM Pokemons";
                return await connection.QueryAsync<Pokemon>(sql);
                //Microsoft.Data.Sqlite.SqliteException: 'SQLite Error 1: 'no such table: Pokemons'.'
            }
        }

        public async Task InsertPokemon(Pokemon pokemon)
        {
            using (var connection = _context.CreateConnection(_isUnitTest))
            {
                string sql = $@"INSERT INTO Pokemons (Name, BirthDate)
                                VALUES (@Name, @BirthDate)";

                await connection.ExecuteAsync(sql, new { pokemon.Name, pokemon.BirthDate });
            }
        }
    }
}
