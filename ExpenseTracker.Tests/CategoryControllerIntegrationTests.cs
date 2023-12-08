using Expense_Tracker.Controllers;
using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ExpenseTracker.Tests
{
    public class CategoryControllerIntegrationTests : IDisposable
    {
        private readonly ApplicationDbContext _context;

        public CategoryControllerIntegrationTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task CreateCategory_ReturnsRedirectToActionResult_WhenModelIsValid()
        {
            // Arrange
            var controller = new CategoryController(_context);
            var category = new Category { Title = "TestCategory" };

            // Act
            var result = await controller.Create(category);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        // Add more integration tests for other actions as needed...

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
