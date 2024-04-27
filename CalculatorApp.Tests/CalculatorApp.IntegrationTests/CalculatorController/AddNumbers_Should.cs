using System.ComponentModel;
using System.Net;
using CalculatorApp.API;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CalculatorApp.Tests.IntegrationTests.CalculatorController
{
	public class AddNumbers_Should : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public AddNumbers_Should(WebApplicationFactory<Program> factory)
		{
			_factory = factory;
		}

        [Fact]
        [DisplayName("UseCase001 AddNumbers ReturnStatusOK")]
        public async Task UseCase001_AddNumbers_ReturnStatusOK()
        {
            // Arrange
            var client = _factory.CreateClient();
            var addend1 = 1;
            var addend2 = 2;

            // Act
            var response = await client.GetAsync($"/add-numbers?Addend1={addend1}&Addend2={addend2}");

            // Assert
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
            var responseBody = await response.Content.ReadAsStringAsync();
            var expectedResult = new Decimal(addend1) + new Decimal(addend2);
            Assert.Equal(expectedResult.ToString(), responseBody);
        }

        [Fact]
        [DisplayName("UseCase002 AddNumbers ReturnStatus400")]
        public async Task UseCase001_AddNumbers_ReturnStatus400()
        {
            // Arrange
            var client = _factory.CreateClient();
            var addend1 = 1;

            // Act
            var response = await client.GetAsync($"/add-numbers?Addend1={addend1}&Addend2=3.1.1");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        [DisplayName("UseCase003 AddNumbers ReturnStatus400 on EmptyRequest")]
        public async Task UseCase001_AddNumbers_ReturnStatus400_EmptyRequest()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/add-numbers");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}

