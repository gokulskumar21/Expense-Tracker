using Expense_Tracker.Models;
using Xunit;

namespace Expense_Tracker.Tests
{
    public class CategoryTests
    {
        [Fact]
        public void Title_Setter_Should_Set_Value()
        {
            // Arrange
            var category = new Category();

            // Act
            category.Title = "Test Title";

            // Assert
            Assert.Equal("Test Title", category.Title);
        }

        [Fact]
        public void Title_Required_Should_Validate()
        {
            // Arrange
            var category = new Category();

            // Act & Assert
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(category, serviceProvider: null, items: null);
            var validationResults = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(category, validationContext, validationResults, validateAllProperties: true);

            Assert.False(isValid);
            Assert.Equal(1, validationResults.Count);
            Assert.Equal("Title is required.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void TitleWithIcon_Should_Return_Correct_Value()
        {
            // Arrange
            var category = new Category
            {
                Title = "Test Title",
                Icon = "TestIcon"
            };

            // Act
            var result = category.TitleWithIcon;

            // Assert
            Assert.Equal("TestIcon Test Title", result);
        }
    }
}
