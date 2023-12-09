using System;
using Expense_Tracker.Models;
using Xunit;

namespace Expense_Tracker.Tests
{
    public class TransactionTests
    {
        [Fact]
        public void CategoryTitleWithIcon_Should_Return_Correct_Value_When_Category_Is_Null()
        {
            // Arrange
            var transaction = new Transaction();

            // Act
            var result = transaction.CategoryTitleWithIcon;

            // Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void CategoryTitleWithIcon_Should_Return_Correct_Value_When_Category_Is_Not_Null()
        {
            // Arrange
            var transaction = new Transaction
            {
                Category = new Category
                {
                    Title = "TestCategory",
                    Icon = "TestIcon"
                }
            };

            // Act
            var result = transaction.CategoryTitleWithIcon;

            // Assert
            Assert.Equal("TestIcon TestCategory", result);
        }

        [Fact]
        public void FormattedAmount_Should_Return_Correct_Value_For_Expense()
        {
            // Arrange
            var transaction = new Transaction
            {
                Amount = 100,
                Category = new Category
                {
                    Type = "Expense"
                }
            };

            // Act
            var result = transaction.FormattedAmount;

            // Assert
            Assert.Equal("- ₹ 100", result);
        }

        [Fact]
        public void FormattedAmount_Should_Return_Correct_Value_For_Income()
        {
            // Arrange
            var transaction = new Transaction
            {
                Amount = 200,
                Category = new Category
                {
                    Type = "Income"
                }
            };

            // Act
            var result = transaction.FormattedAmount;

            // Assert
            Assert.Equal("+ ₹ 200", result);
        }

        [Fact]
        public void FormattedAmount_Should_Return_Correct_Value_For_Unspecified_Type()
        {
            // Arrange
            var transaction = new Transaction
            {
                Amount = 300,
                Category = new Category
                {
                    Type = ""
                }
            };

            // Act
            var result = transaction.FormattedAmount;

            // Assert
            Assert.Equal("+ ₹ 300", result);
        }

        [Fact]
        public void FormattedAmount_Should_Return_Correct_Value_By_Default()
        {
            // Arrange
            var transaction = new Transaction
            {
                Amount = 400
            };

            // Act
            var result = transaction.FormattedAmount;

            // Assert
            Assert.Equal("- ₹ 400", result);
        }
    }
}
