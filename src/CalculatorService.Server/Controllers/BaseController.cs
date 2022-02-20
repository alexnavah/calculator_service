using CalculatorService.Domain.Models.Abstractions;
using CalculatorService.Domain.Models.Error;
using CalculatorService.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Server.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly IMemoryCacheService _memoryCacheService;

        public BaseController(IMemoryCacheService memoryCacheService)
        {
            _memoryCacheService = memoryCacheService;
        }

        public IActionResult HandleComputeResult<T>(T result) where T : OperationResult
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

        public void HandleTracking<T>(T operationResult)
        {
            if (Request.Headers.TryGetValue("X‐Evi‐Tracking‐Id", out var trackingId))
            {

            }
        }
    }
}
