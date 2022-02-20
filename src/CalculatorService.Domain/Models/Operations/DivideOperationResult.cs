using CalculatorService.Domain.Models.Abstractions;
using System;

namespace CalculatorService.Domain.Models.Operations
{
    public class DivideOperationResult : OperationResult
    {
        public DivideOperationResult(int quotient, int remainder)
        {
            Quotient = quotient;
            Remainder = remainder;
        }

        private DivideOperationResult(Exception exception)
        {
            Exception = exception;
        }

        public int Quotient { get; set; }
        public int Remainder { get; set; }

        public static DivideOperationResult Create(int quotient, int remainder)
        {
            return new DivideOperationResult(quotient, remainder);
        }

        public static DivideOperationResult Create(Exception exception)
        {
            return new DivideOperationResult(exception);
        }
    }
}
