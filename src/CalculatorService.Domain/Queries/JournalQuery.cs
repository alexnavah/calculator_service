using CalculatorService.Domain.Services;

namespace CalculatorService.Domain.Queries
{
    public class JournalQuery
    {
        private readonly IMemoryCacheService _memoryCacheService;

        public JournalQuery(IMemoryCacheService memoryCacheService)
        {
            _memoryCacheService = memoryCacheService;
        }

        public void Execute(int trackingId)
        {
            //var records = _memoryCacheService.Get<>
        }
    }
}
