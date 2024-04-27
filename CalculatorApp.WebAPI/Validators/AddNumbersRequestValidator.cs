using System;
using System.Net;
using CalculatorApp.Application.Dtos.Requests;
using CalculatorApp.Application.Messages;
using FluentValidation;

namespace CalculatorApp.WebAPI.Validators
{
    public class AddNumbersRequestValidator : AbstractValidator<AddNumbersRequest>
    {
        public AddNumbersRequestValidator()
        {
            RuleFor(x => x.Addend1)
                .NotEmpty()
                .WithMessage(ResponseMessage.REQUIRED_PARAMETER);
            RuleFor(x => x.Addend2)
                .NotEmpty()
                .WithMessage(ResponseMessage.REQUIRED_PARAMETER);
        }
    }
}

