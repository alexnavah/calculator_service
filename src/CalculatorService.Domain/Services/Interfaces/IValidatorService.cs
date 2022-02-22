using CalculatorService.Domain.Models.Operations;

namespace CalculatorService.Domain.Services.Interfaces
{
    /// <summary>
    /// Handles input parameters values validation such as dividing by zero, etc...
    /// </summary>
    public interface IValidatorService
    {
        bool IsValid(AddOperationParameters parameters);
        bool IsValid(MultiplyOperationParameters parameters);
        bool IsValid(DivideOperationParameters parameters);
        bool IsValid(SquareRootOperationParameters parameters);
    }
}