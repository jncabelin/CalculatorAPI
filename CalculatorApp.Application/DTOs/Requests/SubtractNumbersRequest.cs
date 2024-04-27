using MediatR;
using FluentResults;
using CalculatorApp.Application.Dtos.Responses;

namespace CalculatorApp.Application.Dtos.Requests
{
    public class SubtractNumbersRequest : IRequest<Result<SubtractNumbersResponse>>
    {
        public Decimal Minuend { get; set; }
        public Decimal Subtrahend { get; set; }
    }
}

