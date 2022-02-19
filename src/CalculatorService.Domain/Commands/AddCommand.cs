using CalculatorService.Domain.Commands.Abstractions;
using CalculatorService.Domain.Models;
using System;

namespace CalculatorService.Domain.Commands
{
    public class AddCommand : OperationCommand<AddOperationParameters, AddOperationResult>
    {
        public override AddOperationResult Compute(AddOperationParameters parameters)
        {
            try
            {
                var sum = 0;

                /***
                 * I could use .Sum or .Aggregate from System.Linq but the array is converted into an Enumerable.
                 * This way we only iterate once through every element of the array.
                 */
                for (var i = 0; i < parameters.Addends.Length; i++)
                {
                    sum += parameters.Addends[i];
                }

                return AddOperationResult.Create(sum);
            }
            catch (ArithmeticException exception)
            {
                return AddOperationResult.Create(exception);
            }
        }
    }
}
