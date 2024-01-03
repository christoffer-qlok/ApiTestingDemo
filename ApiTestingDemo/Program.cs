using ApiTestingDemo.Data;
using ApiTestingDemo.Services;
using Microsoft.EntityFrameworkCore;

namespace ApiTestingDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("ApplicationContext");
            builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connectionString));
            builder.Services.AddScoped<IDbHelper, DbHelper>();

            var app = builder.Build();

            app.MapGet("/", ApiHandler.ListGames);
            app.MapPost("/", ApiHandler.AddGame);

            app.Run();
        }
    }
}
