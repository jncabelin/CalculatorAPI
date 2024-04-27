using Microsoft.AspNetCore.Mvc;
using MediatR;
using CalculatorApp.Application.Dtos.Requests;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoffeeMachine.WebApi.Controllers
{

    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private ILogger<CalculatorController> _logger;
        private IMediator _mediator;

        public CalculatorController(IMediator mediator, ILogger<CalculatorController> logger)
        {
            if (mediator == null)
                throw new ArgumentNullException("IMediator cannot be null.");
            if (logger == null)
                throw new ArgumentNullException("ILogger cannot be null.");
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("/add-numbers")]
        public async Task<IActionResult> AddNumbers([FromQuery, BindRequired] AddNumbersRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsFailed)
            {
                _logger.LogInformation("Add Numbers Failure ", result.Reasons.First().Message);
                return new JsonResult(result.Reasons.First().Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }

            _logger.LogInformation("Success", result.Value.Sum);
            return new JsonResult (result.Value.Sum) {
                StatusCode = StatusCodes.Status200OK,
            };
        }

        [HttpGet("/subtract-numbers")]
        public async Task<IActionResult> SubtractNumbers([FromQuery, BindRequired] SubtractNumbersRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsFailed)
            {
                _logger.LogInformation("Subtract Numbers Failure: ", result.Reasons.First().Message);
                return new JsonResult(result.Reasons.First().Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }

            _logger.LogInformation("Success", result.Value.Difference);
            return new JsonResult(result.Value.Difference)
            {
                StatusCode = StatusCodes.Status200OK,
            };
        }

        [HttpGet("/multiply-numbers")]
        public async Task<IActionResult> MultiplyNumbers([FromQuery, BindRequired] MultiplyNumbersRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsFailed)
            {
                _logger.LogInformation("Multiply Numbers Failure: ", result.Reasons.First().Message);
                return new JsonResult(result.Reasons.First().Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }

            _logger.LogInformation("Success", result.Value.Product);
            return new JsonResult(result.Value.Product)
            {
                StatusCode = StatusCodes.Status200OK,
            };
        }

        [HttpGet("/divide-numbers")]
        public async Task<IActionResult> DivideNumbers([FromQuery, BindRequired] DivideNumbersRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsFailed)
            {
                _logger.LogInformation("Divide Numbers Failure: ", result.Reasons.First().Message);
                return new JsonResult(result.Reasons.First().Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }

            _logger.LogInformation("Success", result.Value.Quotient);
            return new JsonResult(result.Value.Quotient)
            {
                StatusCode = StatusCodes.Status200OK,
            };
        }
    }
}

