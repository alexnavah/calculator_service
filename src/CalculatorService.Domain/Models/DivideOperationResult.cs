namespace CalculatorService.Domain.Models
{
    public class DivideOperationResult
    {
        public DivideOperationResult(int quotient, int remainder)
        {
            Quotient = quotient;
            Remainder = remainder;
        }

        public int Quotient { get; set; }
        public int Remainder { get; set; }
    
        public static DivideOperationResult Create(int quotient, int remainder)
        {
            return new DivideOperationResult(quotient, remainder);
        }
    }
}
