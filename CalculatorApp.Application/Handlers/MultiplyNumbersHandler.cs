using MediatR;
using FluentResults;
using CalculatorApp.Api.Services.Interfaces;
using Microsoft.Extensions.Logging;
using CalculatorApp.Application.Dtos.Requests;
using CalculatorApp.Application.Dtos.Responses;

namespace CalculatorApp.Api.Handlers
{
    public class MultiplyNumbersHandler : IRequestHandler<MultiplyNumbersRequest, Result<MultiplyNumbersResponse>>
    {
        private ICalculatorService _calculatorClient;
        private ILogger<MultiplyNumbersHandler> _logger;

        public MultiplyNumbersHandler(ICalculatorService calculatorClient, ILogger<MultiplyNumbersHandler> logger)
        {
            if (calculatorClient == null)
                throw new ArgumentNullException("Calculator Client cannot be null.");
            if (logger == null)
                throw new ArgumentNullException("Logger cannot be null.");

            _calculatorClient = calculatorClient;
            _logger = logger;
        }

        public async Task<Result<MultiplyNumbersResponse>> Handle(MultiplyNumbersRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var result = await _calculatorClient.MultiplyNumbers(request.Multiplicand1, request.Multiplicand2);
            if (result.IsFailed)
                return Result.Fail(result.Reasons.First().Message);

            var response = new MultiplyNumbersResponse { Product = result.Value };

            return Result.Ok(response);
        }
    }
}

