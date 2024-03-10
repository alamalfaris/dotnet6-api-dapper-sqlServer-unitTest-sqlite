using Dapper;
using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Entities;
using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Helpers;
using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Data;

namespace dotnet6_api_dapper_sqlServer_unitTest_sqlite.Databases
{
    public class DatabaseContext
    {
        private readonly ISettingHelper _settingHelper;

        public DatabaseContext(bool isUnitTest = false)
        {
            _settingHelper = new SettingHelper();

            if (isUnitTest)
            {
                InitSqliteDb().GetAwaiter().GetResult();
            }
        }

        public IDbConnection CreateConnection(bool isUnitTest)
        {
            if (isUnitTest)
            {
                return new SqliteConnection("Data Source=LocalDatabase.db");
            }
            else
            {
                var dbConfig = _settingHelper.GetSection("ConnectionDb");
                return new SqlConnection($"Server={dbConfig["Host"]};Database={dbConfig["InitialCatalog"]};Trusted_Connection=true;TrustServerCertificate=true");
            }            
        }

        public async Task InitSqliteDb()
        {
            await CreateTable();
            await InsertDummyData();
        }

        private async Task CreateTable()
        {
            using (var connection = CreateConnection(true))
            {
                string sql = $@"CREATE TABLE IF NOT EXISTS
                                Pokemons (
                                    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT
                                    ,Name TEXT
                                    ,BirthDate TEXT
                                )";

                await connection.ExecuteAsync(sql);
            }
        }

        private async Task InsertDummyData()
        {
            using (var connection = CreateConnection(true))
            {
                string sql = $@"SELECT Id FROM Pokemons";

                var pokemons = await connection.QueryAsync<Pokemon>(sql);
                if (pokemons.Any())
                {
                    sql = $@"DELETE FROM Pokemons";

                    await connection.ExecuteAsync(sql);
                }

                sql = $@"INSERT INTO Pokemons (Name, BirthDate)
                                VALUES 
                                    ('Dummy Poke 1', datetime('now'))
                                    ,('Dummy Poke 2', datetime('now'))";

                await connection.ExecuteAsync(sql);
            }
        }
    }
}
