using MediatR;
using FluentResults;
using CalculatorApp.Api.Services.Interfaces;
using Microsoft.Extensions.Logging;
using CalculatorApp.Application.Dtos.Requests;
using CalculatorApp.Application.Dtos.Responses;

namespace CalculatorApp.Api.Handlers
{
    public class SubtractNumbersHandler : IRequestHandler<SubtractNumbersRequest, Result<SubtractNumbersResponse>>
    {
        private ICalculatorService _calculatorClient;
        private ILogger<SubtractNumbersHandler> _logger;

        public SubtractNumbersHandler(ICalculatorService calculatorClient, ILogger<SubtractNumbersHandler> logger)
        {
            if (calculatorClient == null)
                throw new ArgumentNullException("Calculator Client cannot be null.");
            if (logger == null)
                throw new ArgumentNullException("Logger cannot be null.");

            _calculatorClient = calculatorClient;
            _logger = logger;
        }

        public async Task<Result<SubtractNumbersResponse>> Handle(SubtractNumbersRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var result = await _calculatorClient.SubtractNumbers(request.Minuend, request.Subtrahend);
            if (result.IsFailed)
                return Result.Fail(result.Reasons.First().Message);

            var response = new SubtractNumbersResponse { Difference = result.Value };

            return Result.Ok(response);
        }
    }
}