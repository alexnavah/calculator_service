using CalculatorService.Domain.Commands;
using CalculatorService.Domain.Models;
using System;
using Xunit;

namespace CalculatorService.Server.Tests.Unit.Commands
{
    public class AddCommandTests
    {
        private readonly AddCommand _addCommand;

        public AddCommandTests()
        {
            _addCommand = new AddCommand();
        }

        [Theory]
        [InlineData(new int[3] { 1, 2, 3 }, 6)]
        [InlineData(new int[12] { 4, 3, 2, 1, 3, 4, 5, 6, 7, 6, 4, 2 }, 47)]
        public void ShouldCompute(int[] addends, int sum)
        {
            // Arrange
            var parameters = new AddOperationParameters { Addends = addends };

            // Act
            var result = _addCommand.Compute(parameters);

            // Assert

            Assert.True(result.Success);
            Assert.True(result.Sum.Equals(sum));
        }

        [Fact]
        public void ShouldThrowArithmeticException()
        {
            // Arrange
            var parameters = new AddOperationParameters { Addends = new int[2] { int.MaxValue, 1 } };

            // Act
            var result = _addCommand.Compute(parameters);

            // Assert
            Assert.False(result.Success);
        }
    }
}
