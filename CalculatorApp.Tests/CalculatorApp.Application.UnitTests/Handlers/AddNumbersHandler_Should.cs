using System.ComponentModel;
using CalculatorApp.Api.Services.Interfaces;
using CalculatorApp.Application.Dtos.Requests;
using CalculatorApp.Application.Handlers;
using FluentResults;
using Microsoft.Extensions.Logging;
using Moq;

namespace CalculatorApp.Tests.Application.UnitTests.Handlers
{
	public class AddNumbersHandler_Should
	{
        Mock<ICalculatorService> _calculatorClient;
        Mock<ILogger<AddNumbersHandler>> _logger;
        AddNumbersHandler sut;

        public AddNumbersHandler_Should()
		{
			_calculatorClient = new Mock<ICalculatorService>();
			_logger = new Mock<ILogger<AddNumbersHandler>>();
			sut = new AddNumbersHandler(_calculatorClient.Object, _logger.Object);
		}

        [Fact]
        [DisplayName("Throw Exception if Null ICalculatorService")]
        public void Throw_Exception_if_Null_ICalculatorService()
        {
            // Arrange
            Action testConstructor = () => new AddNumbersHandler(null, _logger.Object);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(testConstructor);
        }

        [Fact]
        [DisplayName("Throw Exception if Null ILogger")]
        public void Throw_Exception_if_Null_ILogger()
        {
            // Arrange
            Action testConstructor = () => new AddNumbersHandler(_calculatorClient.Object, null);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(testConstructor);
        }

        [Fact]
        [DisplayName("Be Created if Valid Parameters")]
        public void Be_Created_if_Valid_Parameters()
        {
            // Act
            var sut = new AddNumbersHandler(_calculatorClient.Object, _logger.Object);

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
            var sum = x + y;
            _calculatorClient.Setup(c => c.AddNumbers(x, y)).ReturnsAsync(Result.Ok(sum));

            // Act
            var result = await sut.Handle(new AddNumbersRequest { Addend1 = x, Addend2 = y }, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(sum, result.Value.Sum);
        }
    }
}

