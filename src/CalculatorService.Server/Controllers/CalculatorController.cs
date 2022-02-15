using CalculatorService.Domain.Commands;
using CalculatorService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : Controller
    {
        private readonly AddCommand _addCommand;
        private readonly SubtractCommand _subtractCommand;
        private readonly MultiplyCommand _multiplyCommand;
        private readonly DivideCommand _divideCommand;

        public CalculatorController(AddCommand addCommand, SubtractCommand subtractCommand, 
            MultiplyCommand multiplyCommand, DivideCommand divideCommand)
        {
            _addCommand = addCommand;
            _subtractCommand = subtractCommand;
            _multiplyCommand = multiplyCommand;
            _divideCommand = divideCommand;
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
