using System.ComponentModel;
using CalculatorApp.Api.Handlers;
using CalculatorApp.Api.Services.Interfaces;
using CalculatorApp.Application.Dtos.Requests;
using CalculatorApp.Application.Messages;
using FluentResults;
using Microsoft.Extensions.Logging;
using Moq;

namespace CalculatorApp.Tests.Application.UnitTests.Handlers
{
	public class DivideNumbersHandler_Should
	{
        Mock<ICalculatorService> _calculatorClient;
        Mock<ILogger<DivideNumbersHandler>> _logger;
        DivideNumbersHandler sut;

        public DivideNumbersHandler_Should()
		{
			_calculatorClient = new Mock<ICalculatorService>();
			_logger = new Mock<ILogger<DivideNumbersHandler>>();
			sut = new DivideNumbersHandler(_calculatorClient.Object, _logger.Object);
		}

        [Fact]
        [DisplayName("Throw Exception if Null ICalculatorService")]
        public void Throw_Exception_if_Null_ICalculatorService()
        {
            // Arrange
            Action testConstructor = () => new DivideNumbersHandler(null, _logger.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(testConstructor);
        }

        [Fact]
        [DisplayName("Throw Exception if Null ILogger")]
        public void Throw_Exception_if_Null_ILogger()
        {
            // Arrange
            Action testConstructor = () => new DivideNumbersHandler(_calculatorClient.Object, null);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(testConstructor);
        }

        [Fact]
        [DisplayName("Be Created if Valid Parameters")]
        public void Be_Created_if_Valid_Parameters()
        {
            // Act
            var sut = new DivideNumbersHandler(_calculatorClient.Object, _logger.Object);

            // Assert
            Assert.NotNull(sut);
        }

        [Fact]
        [DisplayName("Succeed if Valid Parameters")]
        public async Task Succeed_if_Valid_Parameters()
        {
            // Arrange
            var x = new Decimal(1);
            var y = new Decimal(2);
            var quot = x / y;
            _calculatorClient.Setup(c => c.DivideNumbers(x, y)).ReturnsAsync(Result.Ok(quot));

            // Act
            var result = await sut.Handle(new DivideNumbersRequest { Dividend = x, Divisor = y }, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(quot, result.Value.Quotient);
        }

        [Fact]
        [DisplayName("Fail if Indeterminate")]
        public async Task Fail_if_Indeterminate()
        {
            // Arrange
            var x = 0;
            var y = 0;
            _calculatorClient.Setup(c => c.DivideNumbers(x, y)).ReturnsAsync(Result.Fail(ResponseMessage.INDETERMINATE));

            // Act
            var result = await sut.Handle(new DivideNumbersRequest { Dividend = x, Divisor = y }, CancellationToken.None);

            // Assert
            Assert.True(result.IsFailed);
            Assert.Equal(ResponseMessage.INDETERMINATE, result.Reasons.First().Message);
        }

        [Fact]
        [DisplayName("Fail if DivideBy0")]
        public async Task Fail_if_DivideBy0()
        {
            // Arrange
            var x = 1;
            var y = 0;
            _calculatorClient.Setup(c => c.DivideNumbers(x, y)).ReturnsAsync(Result.Fail(ResponseMessage.DIVISION_BY_0));

            // Act
            var result = await sut.Handle(new DivideNumbersRequest { Dividend = x, Divisor = y }, CancellationToken.None);

            // Assert
            Assert.True(result.IsFailed);
            Assert.Equal(ResponseMessage.DIVISION_BY_0, result.Reasons.First().Message);
        }
    }
}

