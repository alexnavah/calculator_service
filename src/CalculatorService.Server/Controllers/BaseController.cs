using CalculatorService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Server.Controllers
{
    public abstract class BaseController : Controller
    {
        public IActionResult HandleComputeResult(OperationResult result)
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

        public IActionResult GetBadRequestError() => BadRequest(ErrorResult.CreateBadRequest());

        public ErrorResult GetInternalServer() => ErrorResult.CreateInternalError();

        public void HandleTracking()
        {
            if (Request.Headers.TryGetValue("X Evi Tracking Id", out var trackingId))
            {

            }
        }
    }
}
