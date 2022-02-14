using CalculatorService.Domain.Models;

namespace CalculatorService.Domain.Commands
{
    public class MultiplyCommand : OperationCommand<MultiplyOperationParameters, MultiplyOperationResult>
    {
        public override MultiplyOperationResult Compute(MultiplyOperationParameters parameters)
        {
            var product = 0;

            /***
             * I could use .Aggregate from System.Linq but the array is converted into an Enumerable.
             * This way we only iterate through every element of the array.
             */
            for (var i = 0; i < parameters.Factors.Length; i++)
            {
                product += parameters.Factors[i];
            }

            return MultiplyOperationResult.Create(product);
        }
    }
}
