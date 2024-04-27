using System;
using System.Net;
using CalculatorApp.Application.Dtos.Requests;
using CalculatorApp.Application.Messages;
using FluentValidation;

namespace CalculatorApp.WebAPI.Validators
{
    public class MultiplyNumbersRequestValidator : AbstractValidator<MultiplyNumbersRequest>
    {
        public MultiplyNumbersRequestValidator()
        {
            RuleFor(x => x.Multiplicand1)
                .NotEmpty()
                .WithMessage(ResponseMessage.REQUIRED_PARAMETER);
            RuleFor(x => x.Multiplicand2)
                .NotEmpty()
                .WithMessage(ResponseMessage.REQUIRED_PARAMETER);
        }
    }
}

