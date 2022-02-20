using CalculatorService.Domain.Commands;
using CalculatorService.Domain.Models.Operations;
using System;
using Xunit;

namespace CalculatorService.Server.Tests.Unit.Commands
{
    public class SquareRootCommandTests
    {
        private readonly SquareRootCommand _squareRootCommand;

        public SquareRootCommandTests()
        {
            _squareRootCommand = new SquareRootCommand();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(int.MaxValue)]
        public void ShouldCompute(int number)
        {
            // Arrange
            var parameters = new SquareRootOperationParameters { Number = number };

            // Act
            var result = _squareRootCommand.Compute(parameters);

            // Assert

            Assert.True(result.Success);
            Assert.True(result.Square.Equals(Math.Sqrt(number)));
        }

        [Fact]
        public void ShouldThrowArithmeticException()
        {
            // Arrange
            var parameters = new SquareRootOperationParameters { Number = int.MinValue };

            // Act
            var result = _squareRootCommand.Compute(parameters);

            // Assert
            Assert.False(result.Success);
        }
    }
}
