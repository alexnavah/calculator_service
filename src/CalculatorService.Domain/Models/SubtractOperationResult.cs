namespace CalculatorService.Domain.Models
{
    public class SubtractOperationResult
    {
        private SubtractOperationResult(int difference)
        {
            Difference = difference;
        }

        public int Difference { get; set; }

        public static SubtractOperationResult Create(int difference)
        {
            return new SubtractOperationResult(difference);
        }
    }
}
