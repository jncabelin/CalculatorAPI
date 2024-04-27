using System.ComponentModel;
using CalculatorApp.Application.Dtos.Requests;
using CalculatorApp.Api.Handlers;
using CalculatorApp.Api.Services.Interfaces;
using FluentResults;
using Microsoft.Extensions.Logging;
using Moq;

namespace CalculatorApp.Tests.Application.UnitTests.Handlers
{
	public class SubtractNumbersHandler_Should
	{
        Mock<ICalculatorService> _calculatorClient;
        Mock<ILogger<SubtractNumbersHandler>> _logger;
        SubtractNumbersHandler sut;

        public SubtractNumbersHandler_Should()
		{
			_calculatorClient = new Mock<ICalculatorService>();
			_logger = new Mock<ILogger<SubtractNumbersHandler>>();
			sut = new SubtractNumbersHandler(_calculatorClient.Object, _logger.Object);
		}

        [Fact]
        [DisplayName("Throw Exception if Null ICalculatorService")]
        public void Throw_Exception_if_Null_ICalculatorService()
        {
            // Arrange
            Action testConstructor = () => new SubtractNumbersHandler(null, _logger.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(testConstructor);
        }

        [Fact]
        [DisplayName("Throw Exception if Null ILogger")]
        public void Throw_Exception_if_Null_ILogger()
        {
            // Arrange
            Action testConstructor = () => new SubtractNumbersHandler(_calculatorClient.Object, null);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(testConstructor);
        }

        [Fact]
        [DisplayName("Be Created if Valid Parameters")]
        public void Be_Created_if_Valid_Parameters()
        {
            // Act
            var sut = new SubtractNumbersHandler(_calculatorClient.Object, _logger.Object);

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
            var diff = x - y;
            _calculatorClient.Setup(c => c.SubtractNumbers(x, y)).ReturnsAsync(Result.Ok(diff));

            // Act
            var result = await sut.Handle(new SubtractNumbersRequest { Minuend = x, Subtrahend = y }, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(diff, result.Value.Difference);
        }
    }
}

