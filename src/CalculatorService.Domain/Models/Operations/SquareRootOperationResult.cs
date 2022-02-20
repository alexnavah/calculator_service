using CalculatorService.Domain.Models.Abstractions;
using System;

namespace CalculatorService.Domain.Models.Operations
{
    public class SquareRootOperationResult : OperationResult
    {
        private SquareRootOperationResult(double square)
        {
            Square = square;
        }

        private SquareRootOperationResult(Exception exception)
        {
            Exception = exception;
        }

        public double Square { get; set; }

        public static SquareRootOperationResult Create(double square)
        {
            return new SquareRootOperationResult(square);
        }

        public static SquareRootOperationResult Create(Exception exception)
        {
            return new SquareRootOperationResult(exception);
        }
    }
}
