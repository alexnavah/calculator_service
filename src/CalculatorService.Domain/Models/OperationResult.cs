using System;

namespace CalculatorService.Domain.Models
{
    public abstract class OperationResult
    {
        public bool Success => Exception != null;
        public Exception Exception { get; set; } 
    }
}