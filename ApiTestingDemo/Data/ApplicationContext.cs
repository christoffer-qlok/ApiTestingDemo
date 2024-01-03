using ApiTestingDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTestingDemo.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}
