using CalculatorService.Domain.Commands;
using CalculatorService.Domain.Models;
using CalculatorService.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : BaseController
    {
        private readonly IValidatorService _validatorService;
        private readonly AddCommand _addCommand;
        private readonly SubtractCommand _subtractCommand;
        private readonly MultiplyCommand _multiplyCommand;
        private readonly DivideCommand _divideCommand;

        public CalculatorController(IValidatorService validatorService, AddCommand addCommand, SubtractCommand subtractCommand, 
            MultiplyCommand multiplyCommand, DivideCommand divideCommand) : base()
        {
            _validatorService = validatorService;
            _addCommand = addCommand;
            _subtractCommand = subtractCommand;
            _multiplyCommand = multiplyCommand;
            _divideCommand = divideCommand;
        }

        [HttpPost("add")]
        public IActionResult Add(AddOperationParameters parameters)
        {
            if (!_validatorService.IsValid(parameters))
            {
                return GetBadRequestError();
            }

            var computeResult = _addCommand.Compute(parameters);

            HandleTracking(computeResult);

            return HandleComputeResult(computeResult);
        }

        [HttpPost("sub")]
        public IActionResult Subtract(SubtractOperationParameters parameters)
        {
            var computeResult = _subtractCommand.Compute(parameters);

            return Ok(computeResult);
        }

        [HttpPost("mult")]
        public IActionResult Multiply(MultiplyOperationParameters parameters)
        {
            var computeResult = _multiplyCommand.Compute(parameters);

            return Ok(computeResult);
        }

        [HttpPost("div")]
        public IActionResult Divide(DivideOperationParameters parameters)
        {
            if (!_validatorService.IsValid(parameters))
            {
                return GetBadRequestError();
            }

            var computeResult = _divideCommand.Compute(parameters);

            return Ok(computeResult);
        }
    }
}
