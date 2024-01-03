using ApiTestingDemo.Data;
using ApiTestingDemo.Models;
using ApiTestingDemo.Models.Dtos;
using ApiTestingDemo.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingDemoTests
{
    [TestClass]
    public class DbHelperTests
    {
        [TestMethod]
        public void AddGame_AddsNewGameToDb()
        {
            // Arrange
            DbContextOptions<ApplicationContext> options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            ApplicationContext context = new ApplicationContext(options);
            DbHelper dbHelper = new DbHelper(context);

            // Act
            dbHelper.AddGame(new GameDto()
            {
                Title = "TestTitle",
                Publisher = "TestPublisher",
                Category = "TestCategory"
            });

            // Assert
            Assert.AreEqual(1, context.Games.Count());
        }
    }
}
