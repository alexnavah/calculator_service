using CalculatorService.Domain.Models.Journal;

namespace CalculatorService.Domain.Queries.Interfaces
{
    /// <summary>
    ///     Interface for querying journal entries
    /// </summary>
    public interface IJournalQuery
    {
        /// <summary>
        ///     Retrieves journal entries (operations) based on the identifier given
        /// </summary>
        /// <param name="trackingId">The tracking identifier</param>
        /// <returns>The <see cref="JournalResult"/> containing each operation with the <paramref name="trackingId"/> given</returns>
        JournalResult Execute(string trackingId);
    }
}