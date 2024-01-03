using ApiTestingDemo;
using ApiTestingDemo.Data;
using ApiTestingDemo.Models;
using ApiTestingDemo.Models.Dtos;
using ApiTestingDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingDemoTests
{
    [TestClass]
    public class ApiHandlerTests
    {
        [TestMethod]
        public void AddGame_CallsDbHelperAddGame()
        {
            // Arrange
            var mockService = new Mock<IDbHelper>();
            IDbHelper dbHelper = mockService.Object;

            GameDto game = new GameDto()
            {
                Title = "TestTitle",
                Publisher = "TestPublisher",
                Category = "TestCategory"
            };

            // Act
            ApiHandler.AddGame(dbHelper, game);

            // Assert
            mockService.Verify(h => h.AddGame(game), Times.Once);
        }
    }
}
