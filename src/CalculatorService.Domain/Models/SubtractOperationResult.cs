﻿using System;

namespace CalculatorService.Domain.Models
{
    public class SubtractOperationResult : OperationResult
    {
        private SubtractOperationResult(int difference)
        {
            Difference = difference;
        }

        private SubtractOperationResult(Exception exception)
        {
            Exception = exception;
        }

        public int Difference { get; set; }

        public static SubtractOperationResult Create(int difference)
        {
            return new SubtractOperationResult(difference);
        }

        public static SubtractOperationResult Create(Exception exception)
        {
            return new SubtractOperationResult(exception);
        }
    }
}
