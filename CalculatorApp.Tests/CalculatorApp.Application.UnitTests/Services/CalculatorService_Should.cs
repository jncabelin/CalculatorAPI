using System.ComponentModel;
using CalculatorApp.Application.Messages;
using CalculatorApp.Application.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace CalculatorApp.Tests.Application.UnitTests.Services
{
	public class CalculatorService_Should
	{
		Mock<ILogger<CalculatorService>> _logger;

		public CalculatorService_Should()
		{
			_logger = new Mock<ILogger<CalculatorService>>();
		}

        [Fact]
        [DisplayName("Throw Exception if Null ILogger")]
        public void Throw_Exception_if_Null_ILogger()
        {
            // Arrange
            Action testConstructor = () => new CalculatorService(null);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(testConstructor);
        }

        [Fact]
        [DisplayName("Succeed to AddNumbers")]
        public async void Succeed_to_AddNumbers()
        {
            // Arrange
            var service = new CalculatorService(_logger.Object);
            var x = new Decimal(1);
            var y = new Decimal(2);
            var sum = x + y;

            // Act
            var result = await service.AddNumbers(x, y);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(sum, result.Value);
        }

        [Fact]
        [DisplayName("Succeed to SubtractNumbers")]
        public async void Succeed_to_SubtractNumbers()
        {
            // Arrange
            var service = new CalculatorService(_logger.Object);
            var x = new Decimal(1);
            var y = new Decimal(2);
            var diff = x - y;

            // Act
            var result = await service.SubtractNumbers(x, y);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(diff, result.Value);
        }

        [Fact]
        [DisplayName("Succeed to MultiplyNumbers")]
        public async void Succeed_to_MultiplyNumbers()
        {
            // Arrange
            var service = new CalculatorService(_logger.Object);
            var x = new Decimal(1);
            var y = new Decimal(2);
            var prod = x * y;

            // Act
            var result = await service.MultiplyNumbers(x, y);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(prod, result.Value);
        }

        [Fact]
        [DisplayName("Succeed to DivideNumbers")]
        public async void Succeed_to_DivideNumbers()
        {
            // Arrange
            var service = new CalculatorService(_logger.Object);
            var x = new Decimal(1);
            var y = new Decimal(2);
            var quot = x / y;

            // Act
            var result = await service.DivideNumbers(x, y);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(quot, result.Value);
        }

        [Fact]
        [DisplayName("Fail to DivideNumbers Indeterminate")]
        public async void Fail_to_DivideNumbers_Indeterminate()
        {
            // Arrange
            var service = new CalculatorService(_logger.Object);
            var x = new Decimal(0);
            var y = new Decimal(0);

            // Act
            var result = await service.DivideNumbers(x, y);

            // Assert
            Assert.True(result.IsFailed);
            Assert.Equal(ResponseMessage.INDETERMINATE, result.Reasons.First().Message);
        }

        [Fact]
        [DisplayName("Fail to DivideNumbers DivideBy0")]
        public async void Fail_to_DivideNumbers_DivideBy0()
        {
            // Arrange
            var service = new CalculatorService(_logger.Object);
            var x = new Decimal(1);
            var y = new Decimal(0);

            // Act
            var result = await service.DivideNumbers(x, y);

            // Assert
            Assert.True(result.IsFailed);
            Assert.Equal(ResponseMessage.DIVISION_BY_0, result.Reasons.First().Message);
        }
    }
}

