namespace dotnet6_api_dapper_sqlServer_unitTest_sqlite.Interfaces
{
    public interface ISettingHelper
    {
        string GetValue(string key);
        IConfigurationSection GetSection(string key);
    }
}
