using CalculatorService.Domain.Commands;
using CalculatorService.Domain.Models;
using Xunit;

namespace CalculatorService.Server.Tests.Unit.Commands
{
    public class DivideCommandTests
    {
        private readonly DivideCommand _divideCommand;

        public DivideCommandTests()
        {
            _divideCommand = new DivideCommand();
        }

        [Theory]
        [InlineData(23, 4, 5, 3)]
        [InlineData(5000000, 312432, 16, 1088)]
        [InlineData(0, 1, 0, 0)]
        public void ShouldCompute(int dividend, int divisor, int quotient, int remainder)
        {
            // Arrange
            var parameters = new DivideOperationParameters { Dividend = dividend, Divisor = divisor };

            // Act
            var result = _divideCommand.Compute(parameters);

            // Act and Assert
            Assert.True(result.Success);
            Assert.True(result.Quotient.Equals(quotient));
            Assert.True(result.Remainder.Equals(remainder));
        }

        [Fact]
        public void ShouldThrowArithmeticException()
        {
            // Arrange
            var parameters = new DivideOperationParameters { Dividend = 1, Divisor = 0 };

            // Act
            var result = _divideCommand.Compute(parameters);

            // Act and Assert
            Assert.False(result.Success);
        }
    }
}
