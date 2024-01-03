using ApiTestingDemo.Data;
using ApiTestingDemo.Models;
using ApiTestingDemo.Models.Dtos;
using ApiTestingDemo.Models.ViewModels;

namespace ApiTestingDemo.Services
{
    public interface IDbHelper
    {
        void AddGame(GameDto game);
        List<ListGameViewModel> GetAllGameTitles();
    }

    public class DbHelper : IDbHelper
    {
        private ApplicationContext _context;

        public DbHelper(ApplicationContext context)
        {
            _context = context;
        }

        public void AddGame(GameDto game)
        {
            _context.Games.Add(new Game()
            {
                Title = game.Title,
                Publisher = game.Publisher,
                Category = game.Category,
            });
            _context.SaveChanges();
        }

        public List<ListGameViewModel> GetAllGameTitles()
        {
            List<ListGameViewModel> games = _context.Games.Select(g => new ListGameViewModel { Title = g.Title }).ToList();
            return games;
        }
    }
}
