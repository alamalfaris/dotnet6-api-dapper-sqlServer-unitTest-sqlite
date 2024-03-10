using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Entities;

namespace dotnet6_api_dapper_sqlServer_unitTest_sqlite.Interfaces
{
    public interface IPokemonRepository
    {
        Task<IEnumerable<Pokemon>> GetPokemons();
    }
}
