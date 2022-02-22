using CalculatorService.Domain.Commands;
using CalculatorService.Domain.Commands.Interfaces;
using CalculatorService.Domain.Queries;
using CalculatorService.Domain.Queries.Interfaces;
using CalculatorService.Domain.Services;
using CalculatorService.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorService.Server.Configuration
{
    /// <summary>
    /// Handles API dependency injection
    /// </summary>
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IMemoryCacheService, MemoryCacheService>();

            services.AddScoped<AddCommand>();
            services.AddScoped<SubtractCommand>();
            services.AddScoped<MultiplyCommand>();
            services.AddScoped<DivideCommand>();
            services.AddScoped<SquareRootCommand>();
            services.AddScoped<IValidatorService, ValidatorService>();
            services.AddScoped<IAddJournalEntryCommand, AddJournalEntryCommand>();
            services.AddScoped<IJournalQuery, JournalQuery>();
        }
    }
}
