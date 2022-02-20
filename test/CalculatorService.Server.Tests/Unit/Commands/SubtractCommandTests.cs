using CalculatorService.Domain.Commands;
using CalculatorService.Domain.Models;
using Xunit;

namespace CalculatorService.Server.Tests.Unit.Commands
{
    public class SubtractCommandTests
    {
        private readonly SubtractCommand _substractCommand;

        public SubtractCommandTests()
        {
            _substractCommand = new SubtractCommand();
        }


        [Theory]
        [InlineData(3, 2, 1)]
        [InlineData(50, 0, 50)]
        public void ShouldCompute(int minuend, int subtraend, int difference)
        {
            // Arrange
            var parameters = new SubtractOperationParameters { Minuend = minuend, Subtrahend = subtraend };

            // Act
            var result = _substractCommand.Compute(parameters);

            // Assert

            Assert.True(result.Success);
            Assert.True(result.Difference.Equals(difference));
        }

        [Fact]
        public void ShouldThrowArithmeticException()
        {
            // Arrange
            var parameters = new SubtractOperationParameters { Minuend = int.MinValue, Subtrahend = 1 };

            // Act
            var result = _substractCommand.Compute(parameters);

            // Assert
            Assert.False(result.Success);
        }
    }
}
