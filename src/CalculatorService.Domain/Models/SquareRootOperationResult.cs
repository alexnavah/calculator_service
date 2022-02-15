namespace CalculatorService.Domain.Models
{
    public class SquareRootOperationResult
    {
        private SquareRootOperationResult(double square)
        {
            Square = square;
        }

        public double Square { get; set; }

        public static SquareRootOperationResult Create(double square)
        {
            return new SquareRootOperationResult(square);
        }
    }
}
