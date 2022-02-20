using CalculatorService.Domain.Commands;
using CalculatorService.Domain.Models.Operations;
using Xunit;

namespace CalculatorService.Server.Tests.Unit.Commands
{
    public class MultiplyCommandTests
    {
        private readonly MultiplyCommand _multiplyCommand;

        public MultiplyCommandTests()
        {
            _multiplyCommand = new MultiplyCommand();
        }

        [Theory]
        [InlineData(new int[3] { 1, 2, 3 }, 6)]
        [InlineData(new int[12] { 4, 3, 2, 1, 3, 4, 5, 6, 7, 6, 4, 2 }, 2903040)]
        [InlineData(new int[12] { 4, 3, 2, 1, 3, 4, 5, 6, 7, 6, 4, 0 }, 0)]
        public void ShouldCompute(int[] factors, int product)
        {
            // Arrange
            var parameters = new MultiplyOperationParameters { Factors = factors };

            // Act
            var result = _multiplyCommand.Compute(parameters);

            // Assert

            Assert.True(result.Success);
            Assert.True(result.Product.Equals(product));
        }

        [Fact]
        public void ShouldThrowArithmeticException()
        {
            // Arrange
            var parameters = new MultiplyOperationParameters { Factors = new int[2] { int.MaxValue, 2 } };

            // Act
            var result = _multiplyCommand.Compute(parameters);

            // Assert
            Assert.False(result.Success);
        }
    }
}
