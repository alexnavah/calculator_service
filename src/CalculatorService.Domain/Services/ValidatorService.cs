﻿using CalculatorService.Domain.Models;
using CalculatorService.Domain.Services.Interfaces;

namespace CalculatorService.Domain.Services
{
    public class ValidatorService : IValidatorService
    {
        public bool IsValid(AddOperationParameters parameters)
        {
            if (parameters.Addends == null)
            {
                return false;
            }

            return true;
        }

        public bool IsValid(DivideOperationParameters parameters)
        {
            if (parameters.Divisor == 0)
            {
                return false;
            }

            return true;
        }
    }
}