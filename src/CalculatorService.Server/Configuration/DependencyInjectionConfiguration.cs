﻿using CalculatorService.Domain.Commands;
using CalculatorService.Domain.Services;
using CalculatorService.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorService.Server.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IMemoryCacheStorage, MemoryCacheStorage>();
            services.AddScoped<AddCommand>();
            services.AddScoped<SubtractCommand>();
            services.AddScoped<MultiplyCommand>();
            services.AddScoped<DivideCommand>();
            services.AddScoped<SquareRootCommand>();
            services.AddScoped<IValidatorService, ValidatorService>();
        }
    }
}
