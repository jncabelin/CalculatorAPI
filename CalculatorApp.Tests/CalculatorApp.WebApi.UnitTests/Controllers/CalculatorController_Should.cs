using System.ComponentModel;
using CalculatorApp.Application.Dtos.Requests;
using CalculatorApp.Application.Dtos.Responses;
using CalculatorApp.Application.Messages;
using CoffeeMachine.WebApi.Controllers;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace CalculatorApp.Tests.WebApi.UnitTests.Controllers
{
	public class CalculatorController_Should
	{
        Mock<ILogger<CalculatorController>> _logger;
        Mock<IMediator> _mediator;
        CalculatorController sut;

        public CalculatorController_Should()
		{
			_logger = new Mock<ILogger<CalculatorController>>();
			_mediator = new Mock<IMediator>();
			sut = new CalculatorController(_mediator.Object, _logger.Object);
		}

        [Fact]
        [DisplayName("Throw Exception if Null IMediator")]
        public void Throw_Exception_if_Null_IMediator()
        {
            // Arrange
            Action testConstructor = () => new CalculatorController(null, _logger.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(testConstructor);
        }

        [Fact]
        [DisplayName("Throw Exception if Null ILogger")]
        public void Throw_Exception_if_Null_ILogger()
        {
            // Arrange
            Action testConstructor = () => new CalculatorController(_mediator.Object, null);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(testConstructor);
        }

        [Fact]
        [DisplayName("Be Successfully Created")]
        public void Be_SuccessfullyCreated()
        {
            // Act
            var sut = new CalculatorController(_mediator.Object, _logger.Object);

            // Act and Assert
            Assert.NotNull(sut);
        }

        [Fact]
        [DisplayName("Return 200 using AddNumbers")]
        public async Task Return200_using_AddNumbers()
        {
            // Arrange
            var x = new Decimal(1);
            var y = new Decimal(2);
            var sum = x + y;
            var okResponse = new AddNumbersResponse { Sum = sum };
            _mediator.Setup(m => m.Send(It.IsAny<AddNumbersRequest>(), CancellationToken.None))
                .ReturnsAsync(Result.Ok(okResponse));

            // Act
            var actionResult = await sut.AddNumbers( new AddNumbersRequest { Addend1 = x, Addend2 = y });
            var objResult = actionResult as JsonResult;

            // Assert
            Assert.NotNull(objResult);
            Assert.Equal(StatusCodes.Status200OK, objResult.StatusCode);
            Assert.Equal(okResponse.Sum, objResult.Value);
        }

        [Fact]
        [DisplayName("Return 500 using AddNumbers")]
        public async Task Return500_using_AddNumbers()
        {
            // Arrange
            _mediator.Setup(m => m.Send(It.IsAny<AddNumbersRequest>(), CancellationToken.None))
                .ReturnsAsync(Result.Fail("Internal Server error"));

            // Act
            var actionResult = await sut.AddNumbers( new AddNumbersRequest());
            var objResult = actionResult as JsonResult;

            // Assert
            Assert.NotNull(objResult);
            Assert.Equal(StatusCodes.Status500InternalServerError, objResult.StatusCode);
        }

        [Fact]
        [DisplayName("Return 200 using SubtractNumbers")]
        public async Task Return200_using_SubtractNumbers()
        {
            // Arrange
            var x = new Decimal(1);
            var y = new Decimal(2);
            var diff = x - y;
            var okResponse = new SubtractNumbersResponse { Difference = diff };
            _mediator.Setup(m => m.Send(It.IsAny<SubtractNumbersRequest>(), CancellationToken.None))
                .ReturnsAsync(Result.Ok(okResponse));

            // Act
            var actionResult = await sut.SubtractNumbers( new SubtractNumbersRequest { Minuend = x, Subtrahend = y });
            var objResult = actionResult as JsonResult;

            // Assert
            Assert.NotNull(objResult);
            Assert.Equal(StatusCodes.Status200OK, objResult.StatusCode);
            Assert.Equal(okResponse.Difference, objResult.Value);
        }

        [Fact]
        [DisplayName("Return 500 using SubtractNumbers")]
        public async Task Return500_using_SubtractNumbers()
        {
            // Arrange
            _mediator.Setup(m => m.Send(It.IsAny<SubtractNumbersRequest>(), CancellationToken.None))
                .ReturnsAsync(Result.Fail("Internal Server error"));

            // Act
            var actionResult = await sut.SubtractNumbers(new SubtractNumbersRequest());
            var objResult = actionResult as JsonResult;

            // Assert
            Assert.NotNull(objResult);
            Assert.Equal(StatusCodes.Status500InternalServerError, objResult.StatusCode);
        }

        [Fact]
        [DisplayName("Return 200 using MultiplyNumbers")]
        public async Task Return200_using_MultiplyNumbers()
        {
            // Arrange
            var x = new Decimal(1);
            var y = new Decimal(2);
            var prod = x * y;
            var okResponse = new MultiplyNumbersResponse { Product = prod };
            _mediator.Setup(m => m.Send(It.IsAny<MultiplyNumbersRequest>(), CancellationToken.None))
                .ReturnsAsync(Result.Ok(okResponse));

            // Act
            var actionResult = await sut.MultiplyNumbers(new MultiplyNumbersRequest { Multiplicand1 = x, Multiplicand2 = y});
            var objResult = actionResult as JsonResult;

            // Assert
            Assert.NotNull(objResult);
            Assert.Equal(StatusCodes.Status200OK, objResult.StatusCode);
            Assert.Equal(okResponse.Product, objResult.Value);
        }

        [Fact]
        [DisplayName("Return 500 using MultiplyNumbers")]
        public async Task Return500_using_MultiplyNumbers()
        {
            // Arrange
            _mediator.Setup(m => m.Send(It.IsAny<MultiplyNumbersRequest>(), CancellationToken.None))
                .ReturnsAsync(Result.Fail("Internal Server error"));

            // Act
            var actionResult = await sut.MultiplyNumbers(new MultiplyNumbersRequest());
            var objResult = actionResult as JsonResult;

            // Assert
            Assert.NotNull(objResult);
            Assert.Equal(StatusCodes.Status500InternalServerError, objResult.StatusCode);
        }

        [Fact]
        [DisplayName("Return 200 using DivideNumbers")]
        public async Task Return200_using_DivideNumbers()
        {
            // Arrange
            var x = new Decimal(1);
            var y = new Decimal(2);
            var quot = x * y;
            var okResponse = new DivideNumbersResponse { Quotient = quot };
            _mediator.Setup(m => m.Send(It.IsAny<DivideNumbersRequest>(), CancellationToken.None))
                .ReturnsAsync(Result.Ok(okResponse));

            // Act
            var actionResult = await sut.DivideNumbers(new DivideNumbersRequest { Dividend = x, Divisor = y});
            var objResult = actionResult as JsonResult;

            // Assert
            Assert.NotNull(objResult);
            Assert.Equal(StatusCodes.Status200OK, objResult.StatusCode);
            Assert.Equal(okResponse.Quotient, objResult.Value);
        }

        [Fact]
        [DisplayName("Return 500 using DivideNumbers")]
        public async Task Return500_using_DivideNumbers()
        {
            // Arrange
            var x = new Decimal(1);
            var y = new Decimal(2);
            _mediator.Setup(m => m.Send(It.IsAny<DivideNumbersRequest>(), CancellationToken.None))
                .ReturnsAsync(Result.Fail("Internal Server error"));

            // Act
            var actionResult = await sut.DivideNumbers(new DivideNumbersRequest { Dividend = x, Divisor = y});
            var objResult = actionResult as JsonResult;

            // Assert
            Assert.NotNull(objResult);
            Assert.Equal(StatusCodes.Status500InternalServerError, objResult.StatusCode);
        }
    }
}

