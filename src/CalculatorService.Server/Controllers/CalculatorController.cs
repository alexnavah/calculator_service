using CalculatorService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : Controller
    {
        public CalculatorController()
        {

        }

        [HttpPost("add")]
        public IActionResult Add(AddOperationParameters parameters)
        {

            return Ok();
        }

        [HttpPost("sub")]
        public IActionResult Subtract(SubtractOperationParameters parameters)
        {

            return Ok();
        }

        [HttpPost("mult")]
        public IActionResult Multiply(MultiplyOperationParameters parameters)
        {

            return Ok();
        }

        [HttpPost("div")]
        public IActionResult Divide(DivideOperationParameters parameters)
        {

            return Ok();
        }
    }
}
