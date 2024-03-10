using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Databases;
using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Interfaces;
using dotnet6_api_dapper_sqlServer_unitTest_sqlite.Repositories;

namespace dotnet6_api_dapper_sqlServer_unitTest_sqlite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSingleton<DatabaseContext>();

            builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
