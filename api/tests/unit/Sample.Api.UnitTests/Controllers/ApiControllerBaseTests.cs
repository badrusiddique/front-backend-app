using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.Controllers;
using Xunit;

namespace Sample.Api.UnitTests.Controllers
{
    public class ApiControllerBaseTests
    {
        private ApiControllerBaseProxy _testObject;

        [Fact]
        public void Verify_OkOrNotFound_ReturnsOK_For_ValidInput()
        {
            // Arrange
            _testObject = new ApiControllerBaseProxy();

            // Act
            var result = _testObject.OkOrNotFoundProxy("some-value").Result;

            // Assert
            var requestResult = result.Should().BeOfType<OkObjectResult>().Which;
            requestResult.StatusCode.Should().Equals(HttpStatusCode.OK);
            requestResult.Value.Should().Be("some-value");
        }

        [Fact]
        public void Verify_OkOrNotFound_ReturnsNotFound_For_InvalidInput()
        {
            // Arrange
            string input = null;
            _testObject = new ApiControllerBaseProxy();

            // Act
            var result = _testObject.OkOrNotFoundProxy(input).Result;

            // Assert
            var requestResult = result.Should().BeOfType<NotFoundResult>().Which;
            requestResult.StatusCode.Should().Equals(HttpStatusCode.NotFound);
        }
    }

    internal class ApiControllerBaseProxy : ApiControllerBase
    {
        public ActionResult<T> OkOrNotFoundProxy<T>(T item) => OkOrNotFound<T>(item);
    }
}