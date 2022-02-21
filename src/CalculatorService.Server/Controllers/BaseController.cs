using CalculatorService.Domain.Models.Abstractions;
using CalculatorService.Domain.Models.Error;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Server.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IActionResult HandleComputeResult<T>(T result) where T : OperationResult
        {
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return GetBadRequestError();
            }
        }

        protected IActionResult GetBadRequestError() => BadRequest(ErrorResult.CreateBadRequest());

        protected ErrorResult GetInternalServer() => ErrorResult.CreateInternalError();        
    }
}
