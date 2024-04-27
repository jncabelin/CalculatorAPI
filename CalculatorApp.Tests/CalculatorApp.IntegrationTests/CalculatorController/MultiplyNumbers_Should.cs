using System;
using System.ComponentModel;
using System.Net;
using CalculatorApp.API;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CalculatorApp.Tests.IntegrationTests.CalculatorController
{
    public class MultiplyNumbers_Should : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public MultiplyNumbers_Should(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        [DisplayName("UseCase001 MultiplyNumbers ReturnStatusOK")]
        public async Task UseCase001_MultiplyNumbers_ReturnStatusOK()
        {
            // Arrange
            var client = _factory.CreateClient();
            var multiplicand1 = 1;
            var multiplicand2 = 2;

            // Act
            var response = await client.GetAsync($"/multiply-numbers?Multiplicand1={multiplicand1}&Multiplicand2={multiplicand2}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseBody = await response.Content.ReadAsStringAsync();
            var expectedResult = new Decimal(multiplicand1) * new Decimal(multiplicand2);
            Assert.Equal(expectedResult.ToString(), responseBody);
        }

        [Fact]
        [DisplayName("UseCase002 MultiplyNumbers ReturnStatus400")]
        public async Task UseCase002_MultiplyNumbers_ReturnStatus400()
        {
            // Arrange
            var client = _factory.CreateClient();
            var multiplicand1 = 1;

            // Act
            var response = await client.GetAsync($"/multiply-numbers?Multiplicand1={multiplicand1}&Multiplicand2=1.3.1");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}

