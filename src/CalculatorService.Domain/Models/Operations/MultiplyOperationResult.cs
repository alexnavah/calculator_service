using CalculatorService.Domain.Models.Abstractions;
using System;

namespace CalculatorService.Domain.Models.Operations
{
    public class MultiplyOperationResult : OperationResult
    {
        private MultiplyOperationResult(int product)
        {
            Product = product;
        }

        private MultiplyOperationResult(Exception exception)
        {
            Exception = exception;
        }

        public int Product { get; set; }

        public static MultiplyOperationResult Create(int product)
        {
            return new MultiplyOperationResult(product);
        }

        public static MultiplyOperationResult Create(Exception exception)
        {
            return new MultiplyOperationResult(exception);
        }
    }
}
