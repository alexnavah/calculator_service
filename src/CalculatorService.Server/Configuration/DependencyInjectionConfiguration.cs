﻿using CalculatorService.Domain.Services;
using CalculatorService.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorService.Server.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IMemoryCacheStorage, MemoryCacheStorage>();
        }
    }
}
