using System;
using System.ComponentModel;
using System.Net;
using CalculatorApp.API;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CalculatorApp.Tests.IntegrationTests.CalculatorController
{
    public class SubtractNumbers_Should : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public SubtractNumbers_Should(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        [DisplayName("UseCase001 SubtractNumbers ReturnStatusOK")]
        public async Task UseCase001_SubtractNumbers_ReturnStatusOK()
        {
            // Arrange
            var client = _factory.CreateClient();
            var minuend = 1;
            var subtrahend = 2;

            // Act
            var response = await client.GetAsync($"/subtract-numbers?Minuend={minuend}&Subtrahend={subtrahend}");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseBody = await response.Content.ReadAsStringAsync();
            var expectedResult = new Decimal(minuend) - new Decimal(subtrahend);
            Assert.Equal(expectedResult.ToString(), responseBody);
        }

        [Fact]
        [DisplayName("UseCase002 SubtractNumbers ReturnStatus400")]
        public async Task UseCase002_SubtractNumbers_ReturnStatus400()
        {
            // Arrange
            var client = _factory.CreateClient();
            var minuend = 1;

            // Act
            var response = await client.GetAsync($"/subtract-numbers?Minuend={minuend}&Subtrahend=1.3.1");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        [DisplayName("UseCase003 SubtractNumbers ReturnStatus400 on EmptyRequest")]
        public async Task UseCase003_SubtractNumbers_ReturnStatus400_EmptyRequest()
        {
            // Arrange
            var client = _factory.CreateClient();
            var minuend = 1;

            // Act
            var response = await client.GetAsync($"/subtract-numbers");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}

