using CalculatorService.Domain.Models.Abstractions;
using CalculatorService.Domain.Models.Error;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Server.Controllers
{
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Handles <see cref="OperationResult"/> result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns>The <see cref="IActionResult"/> base on Success value</returns>
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

        /// <summary>
        /// <see cref="BadRequestResult"/> with a custom error message
        /// </summary>
        protected IActionResult GetBadRequestError() => BadRequest(ErrorResult.CreateBadRequest()); 
    }
}
