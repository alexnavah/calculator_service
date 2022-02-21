using CalculatorService.Domain.Commands;
using CalculatorService.Domain.Commands.Interfaces;
using CalculatorService.Domain.Models.Abstractions;
using CalculatorService.Domain.Models.Extensions;
using CalculatorService.Domain.Models.Journal;
using CalculatorService.Domain.Models.Operations;
using CalculatorService.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : BaseController
    {
        private readonly IValidatorService _validatorService;
        private readonly IAddJournalEntryCommand _addJournalEntryCommand;
        private readonly AddCommand _addCommand;
        private readonly SubtractCommand _subtractCommand;
        private readonly MultiplyCommand _multiplyCommand;
        private readonly DivideCommand _divideCommand;

        public CalculatorController(IValidatorService validatorService, AddCommand addCommand, SubtractCommand subtractCommand,
            MultiplyCommand multiplyCommand, DivideCommand divideCommand, IAddJournalEntryCommand addJournalEntryCommand)
        {
            _validatorService = validatorService;
            _addCommand = addCommand;
            _subtractCommand = subtractCommand;
            _multiplyCommand = multiplyCommand;
            _divideCommand = divideCommand;
            _addJournalEntryCommand = addJournalEntryCommand;
        }

        [HttpPost("add")]
        public IActionResult Add(AddOperationParameters parameters)
        {
            if (!_validatorService.IsValid(parameters))
            {
                return GetBadRequestError();
            }

            var computeResult = _addCommand.Compute(parameters);

            if (computeResult.Success)
            {
                HandleTracking(computeResult.AsJournalEntry(parameters));
            }

            return HandleComputeResult(computeResult);
        }

        [HttpPost("sub")]
        public IActionResult Subtract(SubtractOperationParameters parameters)
        {
            var computeResult = _subtractCommand.Compute(parameters);

            if (computeResult.Success)
            {
                HandleTracking(computeResult.AsJournalEntry(parameters));
            }

            return HandleComputeResult(computeResult);
        }

        [HttpPost("mult")]
        public IActionResult Multiply(MultiplyOperationParameters parameters)
        {
            if (!_validatorService.IsValid(parameters))
            {
                return GetBadRequestError();
            }

            var computeResult = _multiplyCommand.Compute(parameters);

            if (computeResult.Success)
            {
                HandleTracking(computeResult.AsJournalEntry(parameters));
            }

            return HandleComputeResult(computeResult);
        }

        [HttpPost("div")]
        public IActionResult Divide(DivideOperationParameters parameters)
        {
            if (!_validatorService.IsValid(parameters))
            {
                return GetBadRequestError();
            }

            var computeResult = _divideCommand.Compute(parameters);

            if (computeResult.Success)
            {
                HandleTracking(computeResult.AsJournalEntry(parameters));
            }

            return HandleComputeResult(computeResult);
        }

        private void HandleTracking(JournalEntry operationResult)
        {
            if (Request.Headers.TryGetValue("X‐Evi‐Tracking‐Id", out var trackingId) && !string.IsNullOrWhiteSpace(trackingId))
            {
                _addJournalEntryCommand.Insert(trackingId.ToString(), operationResult);
            }
        }
    }
}
