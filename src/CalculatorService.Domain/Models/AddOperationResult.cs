using System;

namespace CalculatorService.Domain.Models
{
    public class AddOperationResult : OperationResult
    {
        private AddOperationResult(int sum)
        {
            Sum = sum;
        }

        private AddOperationResult(Exception exception)
        {
            Exception = exception;
        }

        public int Sum { get; set; }

        public static AddOperationResult Create(int sum)
        {
            return new AddOperationResult(sum);
        }

        public static AddOperationResult Create(Exception exception)
        {
            return new AddOperationResult(exception);
        }
    }
}
