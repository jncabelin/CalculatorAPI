using CalculatorApp.Api.Services.Interfaces;
using CalculatorApp.Application.Messages;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace CalculatorApp.Application.Services
{
    public class CalculatorService : ICalculatorService
    {
        private ILogger<CalculatorService> _logger;

        public CalculatorService(ILogger<CalculatorService> logger)
        {
            if (logger == null)
                throw new ArgumentNullException("Logger cannot be null.");
            _logger = logger;
        }

        public async Task<Result<Decimal>> AddNumbers(Decimal addend1, Decimal addend2)
        {
            await Task.CompletedTask;
            return Result.Ok(addend1 + addend2);
        }

        public async Task<Result<Decimal>> SubtractNumbers(Decimal minuend, Decimal subtrahend)
        {
            await Task.CompletedTask;
            return Result.Ok(minuend - subtrahend);
        }

        public async Task<Result<Decimal>> MultiplyNumbers(Decimal multiplicand1, Decimal multiplicand2)
        {
            await Task.CompletedTask;
            return Result.Ok(multiplicand1 * multiplicand2);
        } 

        public async Task<Result<Decimal>> DivideNumbers(Decimal dividend, Decimal divisor)
        {
            await Task.CompletedTask;
            int end = Decimal.ToInt32(dividend);
            if (Decimal.ToInt32(dividend) == 0 && Decimal.ToInt32(divisor) == 0)
                return Result.Fail(ResponseMessage.INDETERMINATE);

            if (Decimal.ToInt32(divisor) == 0)
                return Result.Fail(ResponseMessage.DIVISION_BY_0);

            return Result.Ok(dividend / divisor);
        }
    }
}