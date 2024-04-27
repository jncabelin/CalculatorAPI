using System;
using System.Net;
using CalculatorApp.Application.Dtos.Requests;
using CalculatorApp.Application.Messages;
using FluentValidation;

namespace CalculatorApp.WebAPI.Validators
{
    public class SubtractNumbersRequestValidator : AbstractValidator<SubtractNumbersRequest>
    {
        public SubtractNumbersRequestValidator()
        {
            RuleFor(x => x.Minuend)
                .NotEmpty()
                .WithMessage(ResponseMessage.REQUIRED_PARAMETER);
            RuleFor(x => x.Subtrahend)
                .NotEmpty()
                .WithMessage(ResponseMessage.REQUIRED_PARAMETER);
        }
    }
}

