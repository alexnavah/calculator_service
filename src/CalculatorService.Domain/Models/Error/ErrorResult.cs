namespace CalculatorService.Domain.Models.Error
{
    public class ErrorResult
    {
        private ErrorResult(string code, ErrorCode status, string message)
        {
            ErrorCode = code;
            ErrorStatus = status;
            ErrorMessage = message;
        }

        public string ErrorCode { get; set; }
        public ErrorCode ErrorStatus { get; set; }
        public string ErrorMessage { get; set; }

        public static ErrorResult CreateBadRequest()
        {
            return new ErrorResult("BadRequest", Error.ErrorCode.BadRequest, "Unable to process request: ...");
        }

        public static ErrorResult CreateInternalError()
        {
            return new ErrorResult("InternalError", Error.ErrorCode.InternalError, "An unexpected error condition was triggered which made impossible to fulfill the request.Please try again or contact support.");
        }
    }
}
