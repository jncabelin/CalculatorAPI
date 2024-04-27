using System;
using System.Net;
using CalculatorApp.Application.Dtos.Requests;
using CalculatorApp.Application.Messages;
using FluentValidation;

namespace CalculatorApp.WebAPI.Validators
{
    public class DivideNumbersRequestValidator : AbstractValidator<DivideNumbersRequest>
    {
        public DivideNumbersRequestValidator()
        {
            RuleFor(x => x.Dividend)
                .NotEmpty()
                .WithMessage(ResponseMessage.REQUIRED_PARAMETER);
            RuleFor(x => x.Divisor)
                .NotEmpty()
                .WithMessage(ResponseMessage.REQUIRED_PARAMETER);
        }
    }
}

