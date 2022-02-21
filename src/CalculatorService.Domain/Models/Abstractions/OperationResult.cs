using CalculatorService.Domain.Models.Journal;
using System;
using System.Text.Json.Serialization;

namespace CalculatorService.Domain.Models.Abstractions
{
    public abstract class OperationResult
    {
        [JsonIgnore]
        public bool Success => Exception == null;
        [JsonIgnore]
        public Exception Exception { get; set; }
    }
}