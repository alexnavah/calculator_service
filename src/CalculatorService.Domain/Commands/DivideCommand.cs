using CalculatorService.Domain.Models;

namespace CalculatorService.Domain.Commands
{
    public class DivideCommand : OperationCommand<DivideOperationParameters, DivideOperationResult>
    {
        public override DivideOperationResult Compute(DivideOperationParameters parameters)
        {
            return null;

            //return DivideOperationResult.Create(quotient, remainder);
        }
    }
}
