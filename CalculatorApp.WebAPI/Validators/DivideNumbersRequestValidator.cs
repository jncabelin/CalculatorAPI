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
                .WithMessage(ResponseMessage.REQUIRED_PARAMETER)
                .NotEqual(new decimal(0))
                .Unless(x => x.Divisor != 0)
                .WithMessage(ResponseMessage.INDETERMINATE);
            RuleFor(x => x.Divisor)
                .NotEmpty()
                .WithMessage(ResponseMessage.REQUIRED_PARAMETER)
                .NotEqual(new decimal(0))
                .WithMessage(ResponseMessage.DIVISION_BY_0);
        }
    }
}

