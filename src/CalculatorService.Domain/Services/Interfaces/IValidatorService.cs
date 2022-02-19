using CalculatorService.Domain.Models;

namespace CalculatorService.Domain.Services.Interfaces
{
    public interface IValidatorService
    {
        bool IsValid(AddOperationParameters parameters);
        bool IsValid(DivideOperationParameters parameters);
    }
}