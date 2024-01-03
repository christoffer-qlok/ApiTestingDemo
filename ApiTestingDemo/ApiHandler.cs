using ApiTestingDemo.Data;
using ApiTestingDemo.Models;
using ApiTestingDemo.Models.Dtos;
using ApiTestingDemo.Models.ViewModels;
using ApiTestingDemo.Services;
using System.Net;

namespace ApiTestingDemo
{
    public static class ApiHandler
    {
        public static IResult AddGame(IDbHelper dbHelper, GameDto game)
        {
            dbHelper.AddGame(game);
            return Results.StatusCode((int)HttpStatusCode.Created);
        }

        public static IResult ListGames(IDbHelper dbHelper)
        {
            var games = dbHelper.GetAllGameTitles();
            return Results.Json(games);
        }
    }
}
