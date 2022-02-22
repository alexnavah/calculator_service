using CalculatorService.Domain.Models.Operations;

namespace CalculatorService.Domain.Services.Interfaces
{
    public interface IValidatorService
    {
        bool IsValid(AddOperationParameters parameters);
        bool IsValid(MultiplyOperationParameters parameters);
        bool IsValid(DivideOperationParameters parameters);
        bool IsValid(SquareRootOperationParameters parameters);
    }
}