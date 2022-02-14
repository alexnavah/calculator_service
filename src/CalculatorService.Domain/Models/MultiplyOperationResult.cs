namespace CalculatorService.Domain.Models
{
    public class MultiplyOperationResult
    {
        private MultiplyOperationResult(int product)
        {
            Product = product;
        }
        public int Product { get; set; }

        public static MultiplyOperationResult Create(int product)
        {
            return new MultiplyOperationResult(product);
        }
    }
}
