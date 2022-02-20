using CalculatorService.Domain.Commands.Abstractions;
using CalculatorService.Domain.Models.Operations;
using System;

namespace CalculatorService.Domain.Commands
{
    public class DivideCommand : OperationCommand<DivideOperationParameters, DivideOperationResult>
    {
        public override DivideOperationResult Compute(DivideOperationParameters parameters)
        {
            try
            {
                var quotient = Math.DivRem(parameters.Dividend, parameters.Divisor, out var remainder);

                return DivideOperationResult.Create(quotient, remainder);
            }
            catch (ArithmeticException exception)
            {
                return DivideOperationResult.Create(exception);
            }
        }
    }
}
