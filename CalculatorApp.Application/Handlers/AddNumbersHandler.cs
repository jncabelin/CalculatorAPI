using MediatR;
using FluentResults;
using CalculatorApp.Api.Services.Interfaces;
using Microsoft.Extensions.Logging;
using CalculatorApp.Application.Dtos.Requests;
using CalculatorApp.Application.Dtos.Responses;

namespace CalculatorApp.Application.Handlers
{
    public class AddNumbersHandler : IRequestHandler<AddNumbersRequest, Result<AddNumbersResponse>>
    {
        private ICalculatorService _calculatorClient;
        private ILogger<AddNumbersHandler> _logger;

        public AddNumbersHandler(ICalculatorService calculatorClient, ILogger<AddNumbersHandler> logger)
        {
            if (calculatorClient == null)
                throw new ArgumentNullException("Calculator Client cannot be null.");
            if (logger == null)
                throw new ArgumentNullException("Logger cannot be null.");

            _calculatorClient = calculatorClient;
            _logger = logger;
        }

        public async Task<Result<AddNumbersResponse>> Handle(AddNumbersRequest request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var result = await _calculatorClient.AddNumbers(request.Addend1, request.Addend2);
            if (result.IsFailed)
                return Result.Fail(result.Reasons.First().Message);

            var response = new AddNumbersResponse { Sum = result.Value };

            return Result.Ok(response);
        }
    }
}

