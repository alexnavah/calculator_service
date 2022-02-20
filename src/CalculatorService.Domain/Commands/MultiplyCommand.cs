using CalculatorService.Domain.Commands.Abstractions;
using CalculatorService.Domain.Models;
using System;

namespace CalculatorService.Domain.Commands
{
    public class MultiplyCommand : OperationCommand<MultiplyOperationParameters, MultiplyOperationResult>
    {
        public override MultiplyOperationResult Compute(MultiplyOperationParameters parameters)
        {
            try
            {
                var product = 1;

                /***
                 * If last value in the array is zero, the result will be zero, so iteration is pointless.
                 */
                if (parameters.Factors[parameters.Factors.Length - 1].Equals(0))
                {
                    return MultiplyOperationResult.Create(0);
                }

                /***
                 * I could use .Aggregate from System.Linq but the array is converted into an Enumerable.
                 * This way we only iterate one through every element of the array.
                 */
                for (var i = 0; i < parameters.Factors.Length; i++)
                {
                    product *= parameters.Factors[i];
                }

                return MultiplyOperationResult.Create(product);
            }
            catch (ArithmeticException exception)
            {
                return MultiplyOperationResult.Create(exception);
            }
        }
    }
}
