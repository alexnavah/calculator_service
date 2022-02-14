using CalculatorService.Domain.Models;

namespace CalculatorService.Domain.Commands
{
    public class SubtractCommand : OperationCommand<SubtractOperationParameters, SubtractOperationResult>
    {
        public override SubtractOperationResult Compute(SubtractOperationParameters parameters)
        {
            var difference = parameters.Minuend - parameters.Subtrahend;

            return SubtractOperationResult.Create(difference);
        }
    }
}
