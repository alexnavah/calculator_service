using CalculatorService.Domain.Models.Operations;
using CalculatorService.Domain.Services.Interfaces;

namespace CalculatorService.Domain.Services
{
    /// <inheritdoc cref="IValidatorService"/>
    public class ValidatorService : IValidatorService
    {
        public bool IsValid(AddOperationParameters parameters)
        {
            if (parameters.Addends == null)
            {
                return false;
            }

            return true;
        }

        public bool IsValid(MultiplyOperationParameters parameters)
        {
            if (parameters.Factors == null)
            {
                return false;
            }

            return true;
        }

        public bool IsValid(DivideOperationParameters parameters)
        {
            if (parameters.Divisor == 0)
            {
                return false;
            }

            return true;
        }

        public bool IsValid(SquareRootOperationParameters parameters)
        {
            if(parameters.Number < 0)
            {
                return false;
            }

            return true;
        }
    }
}
