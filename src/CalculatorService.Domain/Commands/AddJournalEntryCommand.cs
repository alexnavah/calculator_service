using CalculatorService.Domain.Commands.Interfaces;
using CalculatorService.Domain.Models.Journal;
using CalculatorService.Domain.Services;

namespace CalculatorService.Domain.Commands
{
    public class AddJournalEntryCommand : IAddJournalEntryCommand
    {
        private readonly IMemoryCacheService _memoryCacheService;

        public AddJournalEntryCommand(IMemoryCacheService memoryCacheService)
        {
            _memoryCacheService = memoryCacheService;
        }

        public bool Insert(string trackingId, JournalEntry entry)
        {
            try
            {
                var journal = _memoryCacheService.Get<JournalResult>(trackingId);

                if (journal == null)
                {
                    journal = JournalResult.Create(trackingId, entry);
                }
                else
                {
                    journal.AddEntry(entry);
                }

                _memoryCacheService.Set(trackingId, journal);

            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}
