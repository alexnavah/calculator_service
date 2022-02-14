namespace CalculatorService.Server.Models
{
    public class ErrorResult
    {
        public string ErrorCode { get; set; }
        public int ErrorStatus { get; set; }
        public string ErrorMessage { get; set; }
    }
}
