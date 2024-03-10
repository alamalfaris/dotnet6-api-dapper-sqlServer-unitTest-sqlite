using Dapper;
using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Databases;
using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Entities;
using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Interfaces;

namespace dotnet6_api_dapper_sqlServer_unitTest_sqlite.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DatabaseContext _context;

        public PokemonRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pokemon>> GetPokemons()
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = $@"SELECT * FROM Pokemons";
                return await connection.QueryAsync<Pokemon>(sql);
            }
        }
    }
}
