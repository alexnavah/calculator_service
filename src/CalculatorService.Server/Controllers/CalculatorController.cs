using CalculatorService.Domain.Commands;
using CalculatorService.Domain.Commands.Interfaces;
using CalculatorService.Domain.Models.Extensions;
using CalculatorService.Domain.Models.Journal;
using CalculatorService.Domain.Models.Operations;
using CalculatorService.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CalculatorService.Server.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class CalculatorController : BaseController
    {
        private readonly IValidatorService _validatorService;
        private readonly IAddJournalEntryCommand _addJournalEntryCommand;
        private readonly AddCommand _addCommand;
        private readonly SubtractCommand _subtractCommand;
        private readonly MultiplyCommand _multiplyCommand;
        private readonly DivideCommand _divideCommand;
        private readonly SquareRootCommand _squareRootCommand;

        public CalculatorController(IValidatorService validatorService, AddCommand addCommand, SubtractCommand subtractCommand,
            MultiplyCommand multiplyCommand, DivideCommand divideCommand, SquareRootCommand squareRootCommand, IAddJournalEntryCommand addJournalEntryCommand)
        {
            _validatorService = validatorService;
            _addCommand = addCommand;
            _subtractCommand = subtractCommand;
            _multiplyCommand = multiplyCommand;
            _divideCommand = divideCommand;
            _squareRootCommand = squareRootCommand;
            _addJournalEntryCommand = addJournalEntryCommand;
        }

        [HttpPost("[controller]/add")]
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

        [HttpPost("[controller]/sub")]
        public IActionResult Subtract(SubtractOperationParameters parameters)
        {
            var computeResult = _subtractCommand.Compute(parameters);

            if (computeResult.Success)
            {
                HandleTracking(computeResult.AsJournalEntry(parameters));
            }

            return HandleComputeResult(computeResult);
        }

        [HttpPost("[controller]/mult")]
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

        [HttpPost("[controller]/div")]
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
        
        [HttpPost("sqrt")]
        public IActionResult SquareRoot(SquareRootOperationParameters parameters)
        {
            if (!_validatorService.IsValid(parameters))
            {
                return GetBadRequestError();
            }

            var computeResult = _squareRootCommand.Compute(parameters);

            if (computeResult.Success)
            {
                HandleTracking(computeResult.AsJournalEntry(parameters));
            }

            return HandleComputeResult(computeResult);
        }

        private void HandleTracking(JournalEntry operationResult)
        {
            if (Request.Headers.TryGetValue(@"X-Evi-Tracking-Id", out var trackingId) && !string.IsNullOrWhiteSpace(trackingId))
            {
                _addJournalEntryCommand.Insert(trackingId.ToString(), operationResult);
            }
        }
    }
}
