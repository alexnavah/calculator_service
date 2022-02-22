using CalculatorService.Domain.Models.Journal;
using CalculatorService.Domain.Queries.Interfaces;
using CalculatorService.Domain.Services;

namespace CalculatorService.Domain.Queries
{
    public class JournalQuery : IJournalQuery
    {
        private readonly IMemoryCacheService _memoryCacheService;

        /// <inheritdoc cref="IJournalQuery"/>
        public JournalQuery(IMemoryCacheService memoryCacheService)
        {
            _memoryCacheService = memoryCacheService;
        }

        /// <inheritdoc cref="IJournalQuery.Execute(string)"/>
        public JournalResult Execute(string trackingId)
        {
            var records = _memoryCacheService.Get<JournalResult>(trackingId);

            return records ?? JournalResult.Create();
        }
    }
}
