namespace CalculatorService.Domain.Models
{
    public class AddOperationResult
    {
        private AddOperationResult(int sum)
        {
            Sum = sum;
        }

        public int Sum { get; set; }

        public static AddOperationResult Create(int sum)
        {
            return new AddOperationResult(sum);
        }
    }
}
