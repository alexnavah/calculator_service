using CalculatorService.Domain.Models.Journal;

namespace CalculatorService.Domain.Queries.Interfaces
{
    public interface IJournalQuery
    {
        JournalResult Execute(string trackingId);
    }
}