using CalculatorService.Domain.Models.Journal;
using CalculatorService.Domain.Models.Operations;

namespace CalculatorService.Domain.Models.Extensions
{
    public static class OperationResultExtensions
    {
        public static JournalEntry AsJournalEntry(this AddOperationResult result, AddOperationParameters parameters)
        {
            return JournalEntry.Create(OperationType.Sum.ToString(), $"{string.Join(" + ", parameters.Addends)} = {result.Sum}");
        }

        public static JournalEntry AsJournalEntry(this SubtractOperationResult result, SubtractOperationParameters parameters)
        {
            return JournalEntry.Create(OperationType.Subtract.ToString(), $"{parameters.Minuend} - {parameters.Subtrahend} = {result.Difference}");
        }

        public static JournalEntry AsJournalEntry(this MultiplyOperationResult result, MultiplyOperationParameters parameters)
        {
            return JournalEntry.Create(OperationType.Multiply.ToString(), $"{string.Join(" * ", parameters.Factors)} = {result.Product}");
        }

        public static JournalEntry AsJournalEntry(this DivideOperationResult result, DivideOperationParameters parameters)
        {
            return JournalEntry.Create(OperationType.Divide.ToString(), $"{parameters.Dividend} / {parameters.Divisor} = Q:{result.Quotient} R:{result.Remainder}");
        }

        public static JournalEntry AsJournalEntry(this SquareRootOperationResult result, SquareRootOperationParameters parameters)
        {
            return JournalEntry.Create(OperationType.SquareRoot.ToString(), $"√{parameters.Number} = {result.Square}");
        }
    }
}
