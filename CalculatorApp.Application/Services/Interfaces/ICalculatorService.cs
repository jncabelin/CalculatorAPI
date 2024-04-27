using FluentResults;

namespace CalculatorApp.Api.Services.Interfaces
{
    public interface ICalculatorService
    {
        public Task<Result<Decimal>> AddNumbers(Decimal addend1, Decimal addend2);
        public Task<Result<Decimal>> SubtractNumbers(Decimal minuend, Decimal subtrahend);
        public Task<Result<Decimal>> MultiplyNumbers(Decimal multiplicand1, Decimal multiplicand2);
        public Task<Result<Decimal>> DivideNumbers(Decimal dividend, Decimal divisor);
    }
}