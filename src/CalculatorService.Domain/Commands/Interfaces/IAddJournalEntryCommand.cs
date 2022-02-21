using CalculatorService.Domain.Models.Journal;

namespace CalculatorService.Domain.Commands.Interfaces
{
    public interface IAddJournalEntryCommand
    {
        bool Insert(string trackingId, JournalEntry entry);
    }
}
