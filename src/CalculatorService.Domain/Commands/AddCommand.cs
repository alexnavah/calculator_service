using CalculatorService.Domain.Models;

namespace CalculatorService.Domain.Commands
{
    public class AddCommand : OperationCommand<AddOperationParameters, AddOperationResult>
    {
        public override AddOperationResult Compute(AddOperationParameters parameters)
        {
            var sum = 0;

            /***
             * I could use .Sum or .Aggregate from System.Linq but the array is converted into an Enumerable.
             * This way we only iterate through every element of the array.
             */
            for (var i = 0; i < parameters.Addends.Length; i++)
            {
                sum += parameters.Addends[i];
            }

            return AddOperationResult.Create(sum);
        }
    }
}
