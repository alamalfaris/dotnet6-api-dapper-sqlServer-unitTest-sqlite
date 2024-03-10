using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Helpers;
using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace dotnet6_api_dapper_sqlServer_unitTest_sqlite.Databases
{
    public class DatabaseContext
    {
        private readonly ISettingHelper _settingHelper;

        public DatabaseContext()
        {
            _settingHelper = new SettingHelper();
        }

        public IDbConnection CreateConnection()
        {
            var dbConfig = _settingHelper.GetSection("ConnectionDb");
            return new SqlConnection($"Server={dbConfig["Host"]};Database={dbConfig["InitialCatalog"]};Trusted_Connection=true;TrustServerCertificate=true");
        }
    }
}
