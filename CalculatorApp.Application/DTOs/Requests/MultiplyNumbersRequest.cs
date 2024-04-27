using MediatR;
using FluentResults;
using CalculatorApp.Application.Dtos.Responses;

namespace CalculatorApp.Application.Dtos.Requests
{
    public class MultiplyNumbersRequest : IRequest<Result<MultiplyNumbersResponse>>
    {
        public Decimal Multiplicand1 { get; set; }
        public Decimal Multiplicand2 { get; set; }
    }
}

