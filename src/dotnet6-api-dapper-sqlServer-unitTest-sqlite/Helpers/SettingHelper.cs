using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Interfaces;
using Microsoft.Extensions.Configuration;

namespace dotnet6_api_dapper_sqlServer_unitTest_sqlite.Helpers
{
    public class SettingHelper : ISettingHelper
    {
        private readonly IConfigurationRoot _configuration;

        public SettingHelper()
        {
            _configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
        }

        public string GetValue(string key)
        {
            return _configuration.GetSection(key).Value;
        }

        public IConfigurationSection GetSection(string key)
        {
            return _configuration.GetSection(key);
        }
    }
}
