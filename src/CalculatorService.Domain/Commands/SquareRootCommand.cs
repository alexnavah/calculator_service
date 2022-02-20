using CalculatorService.Domain.Commands.Abstractions;
using CalculatorService.Domain.Models.Operations;
using System;

namespace CalculatorService.Domain.Commands
{
    public class SquareRootCommand : OperationCommand<SquareRootOperationParameters, SquareRootOperationResult>
    {
        public override SquareRootOperationResult Compute(SquareRootOperationParameters parameters)
        {
            try
            {
                var square = Math.Sqrt(parameters.Number);

                // C# support Not-a-Number result in double type operations, so we need to manually check for it
                if (square.Equals(double.NaN))
                {
                    throw new NotFiniteNumberException();
                }

                return SquareRootOperationResult.Create(square);
            }
            catch (ArithmeticException exception)
            {
                return SquareRootOperationResult.Create(exception);
            }
        }
    }
}
