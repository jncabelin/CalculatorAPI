using MediatR;
using FluentResults;
using CalculatorApp.Application.Dtos.Responses;

namespace CalculatorApp.Application.Dtos.Requests
{
    public class AddNumbersRequest : IRequest<Result<AddNumbersResponse>>
    {
        public Decimal Addend1 { get; set; }
        public Decimal Addend2 { get; set; }
    }
}

