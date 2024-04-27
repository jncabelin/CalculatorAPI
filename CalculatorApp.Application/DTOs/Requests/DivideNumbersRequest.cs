using MediatR;
using FluentResults;
using CalculatorApp.Application.Dtos.Responses;

namespace CalculatorApp.Application.Dtos.Requests
{
    public class DivideNumbersRequest : IRequest<Result<DivideNumbersResponse>>
    {
        public Decimal Dividend { get; set; }
        public Decimal Divisor { get; set; }
    }
}

