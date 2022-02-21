using System;

namespace CalculatorService.Domain.Models.Journal
{
    public class JournalEntry
    {
        private JournalEntry(string operation, string calculation)
        {
            Operation = operation;
            Calculation = calculation;
            Date = DateTime.Now.ToString("u");
        }

        public string Operation { get; set; }
        public string Calculation { get; set; }
        public string Date { get; set; }

        public static JournalEntry Create(string operation, string calculation)
        {
            return new JournalEntry(operation, calculation);
        }
    }
}
