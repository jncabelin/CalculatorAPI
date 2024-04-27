using MediatR;
using FluentResults;
using CalculatorApp.Api.Services.Interfaces;
using Microsoft.Extensions.Logging;
using CalculatorApp.Application.Dtos.Requests;
using CalculatorApp.Application.Dtos.Responses;

namespace CalculatorApp.Api.Handlers
{
    public class DivideNumbersHandler : IRequestHandler<DivideNumbersRequest, Result<DivideNumbersResponse>>
    {
        private ICalculatorService _calculatorClient;
        private ILogger<DivideNumbersHandler> _logger;

        public DivideNumbersHandler(ICalculatorService calculatorClient, ILogger<DivideNumbersHandler> logger)
        {
            if (calculatorClient == null)
                throw new ArgumentNullException("Calculator Client cannot be null.");
            if (logger == null)
                throw new ArgumentNullException("Logger cannot be null.");

            _calculatorClient = calculatorClient;
            _logger = logger;
        }

        public async Task<Result<DivideNumbersResponse>> Handle(DivideNumbersRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var result = await _calculatorClient.DivideNumbers(request.Dividend, request.Divisor);
            if (result.IsFailed)
                return Result.Fail(result.Reasons.First().Message);

            var response = new DivideNumbersResponse { Quotient = result.Value };

            return Result.Ok(response);
        }
    }
}

