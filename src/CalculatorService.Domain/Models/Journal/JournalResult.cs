using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CalculatorService.Domain.Models.Journal
{
    public class JournalResult
    {
        public JournalResult(string trackingId, JournalEntry entry)
        {
            TrackingId = trackingId;
            Operations = new Queue<JournalEntry>();
            Operations.Enqueue(entry);
        }

        [JsonIgnore]
        public string TrackingId { get; set; }
        public Queue<JournalEntry> Operations { get; set; }

        public static JournalResult Create(string trackingId, JournalEntry entry)
        {
            return new JournalResult(trackingId, entry);
        }

        public void AddEntry(JournalEntry entry)
        {
            Operations.Enqueue(entry);
        }
    }
}
