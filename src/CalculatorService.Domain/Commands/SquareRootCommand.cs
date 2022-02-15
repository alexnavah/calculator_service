using CalculatorService.Domain.Models;
using System;

namespace CalculatorService.Domain.Commands
{
    public class SquareRootCommand : OperationCommand<SquareRootOperationParameters, SquareRootOperationResult>
    {
        public override SquareRootOperationResult Compute(SquareRootOperationParameters parameters)
        {
            var square = Math.Sqrt(parameters.Number);

            return SquareRootOperationResult.Create(square);
        }
    }
}
