using System;
using System.ComponentModel;
using System.Net;
using CalculatorApp.API;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CalculatorApp.Tests.IntegrationTests.CalculatorController
{
    public class DivideNumbers_Should : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public DivideNumbers_Should(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        [DisplayName("UseCase001 DivideNumbers ReturnStatusOK")]
        public async Task UseCase001_DivideNumbers_ReturnStatusOK()
        {
            // Arrange
            var client = _factory.CreateClient();
            var dividend = 1;
            var divisor = 2;

            // Act
            var response = await client.GetAsync($"/divide-numbers?Dividend={dividend}&Divisor={divisor}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseBody = await response.Content.ReadAsStringAsync();
            var expectedResult = new Decimal(dividend) / new Decimal(divisor);
            Assert.Equal(expectedResult.ToString(), responseBody);
        }

        [Fact]
        [DisplayName("UseCase002 DivideNumbers InvalidParameters ReturnStatus400")]
        public async Task UseCase002_DivideNumbers_InvalidParameters_ReturnStatus400()
        {
            // Arrange
            var client = _factory.CreateClient();
            var dividend = 1;

            // Act
            var response = await client.GetAsync($"/divide-numbers?Dividend={dividend}&Divisor=1.3.1");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        [DisplayName("UseCase003 DivideNumbers ReturnStatus400 on EmptyRequest")]
        public async Task UseCase003_DivideNumbers_ReturnStatus400_EmptyRequest()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/divide-numbers");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}

