using CalculatorService.Domain.Commands.Abstractions;
using CalculatorService.Domain.Models;
using CalculatorService.Domain.Models.Operations;
using System;

namespace CalculatorService.Domain.Commands
{
    public class SubtractCommand : OperationCommand<SubtractOperationParameters, SubtractOperationResult>
    {
        public override SubtractOperationResult Compute(SubtractOperationParameters parameters)
        {
            try
            {
                var difference = parameters.Minuend - parameters.Subtrahend;

                return SubtractOperationResult.Create(difference);
            }
            catch (ArithmeticException exception)
            {
                return SubtractOperationResult.Create(exception);
            }
        }
    }
}
