using System;
using System.Text.Json.Serialization;

namespace CalculatorService.Domain.Models
{
    public abstract class OperationResult
    {
        [JsonIgnore]
        public bool Success => Exception == null;
        [JsonIgnore]
        public Exception Exception { get; set; } 
    }
}