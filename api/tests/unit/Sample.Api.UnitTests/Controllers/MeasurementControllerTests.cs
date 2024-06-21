using System;
using System.Net;
using AutoMapper;
using FluentAssertions;
using Moq;
using Sample.Api.Controllers;
using Sample.Api.Responses;
using Sample.Mapper.DTOs.Request;
using Sample.Mapper.DTOs.Response;
using Sample.Mapper.Models;
using Sample.Orchestrator.Services.Interfaces;
using Xunit;

namespace Sample.Api.UnitTests.Controllers
{
    public class MeasurementControllerTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly MeasurementsController _testObject;
        private readonly Mock<IMeasurementService> _mockService;

        public MeasurementControllerTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockService = new Mock<IMeasurementService>();
            _testObject = new MeasurementsController(_mockMapper.Object,_mockService.Object);
        }

        #region GetByIdAsync

        [Fact]
        public async void Verify_GetByIdAsync_Returns_Measurement_For_ValidInput()
        {
            // Arrange
            var measurementId = Guid.NewGuid();
            var stubModel = new MeasurementModel { Name = "sample-name-1", Id = measurementId };
            var stubResponseDto = new MeasurementResponseDto { Name = "sample-name-1", Id = measurementId };
            _mockService.
                Setup(x => x.GetMeasurementByIdAsync(measurementId))
                .ReturnsAsync(stubModel)
                .Verifiable();
            SetupMapperMock(stubModel, stubResponseDto);

            // Act
            var result = await _testObject.GetByIdAsync(measurementId);

            // Assert
            _mockService.Verify();
            var requestResult = result.Should().BeOfType<ApiResponse<MeasurementResponseDto>>().Which;
            requestResult.StatusCode.Should().Be(HttpStatusCode.OK);
            requestResult.Data.Should().BeEquivalentTo(stubResponseDto);
            requestResult.Error.Should().BeNull();
        }

        [Fact]
        public async void Verify_GetByIdAsync_Returns_NotFound_If_MeasurementIsNull()
        {
            // Arrange
            _mockService.
                Setup(x => x.GetMeasurementByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((MeasurementModel)null)
                .Verifiable();

            // Act
            var result = await _testObject.GetByIdAsync(Guid.NewGuid());

            // Assert
            _mockService.Verify();
            var requestResult = result.Should().BeOfType<ApiResponse<MeasurementResponseDto>>().Which;
           requestResult.Data.Should().BeNull();
            requestResult.Error.Should().NotBeNull();
        }

        #endregion

        #region CreateAsync

        [Fact]
        public async void Verify_CreateAsync_Returns_Measurement_For_ValidInput()
        {
            // Arrange
            var applicationId = Guid.NewGuid();
            var inputData = new MeasurementRequestDto { Name = "sample-name" };
            var stubModel = new MeasurementModel { Name = "sample-name-1" };
            var stubResponseDto = new MeasurementResponseDto { Name = "sample-name-1" };
            _mockService
                .Setup(x => x.CreateMeasurementAsync(inputData))
                .ReturnsAsync(stubModel)
                .Verifiable();
            SetupMapperMock(stubModel, stubResponseDto);

            // Act
            var result = await _testObject.CreateAsync(inputData);

            // Assert
            _mockService.Verify();
            var requestResult = result.Should().BeOfType<ApiResponse<MeasurementResponseDto>>().Which;
            requestResult.StatusCode.Should().Be(HttpStatusCode.OK);
            requestResult.Data.Should().BeEquivalentTo(stubResponseDto);
            requestResult.Error.Should().BeNull();
        }

        #endregion

        #region UpdateByIdAsync

        [Fact]
        public async void Verify_UpdateByIdAsync_Returns_OK_For_ValidInput()
        {
            // Arrange
            var measurementId = Guid.NewGuid();
            var inputData = new MeasurementRequestDto { Id = measurementId, Name = "sample-name" };
            _mockService
                .Setup(x => x.UpdateMeasurementByIdAsync(measurementId, inputData))
                .Verifiable();

            // Act
            var result = await _testObject.UpdateByIdAsync(measurementId, inputData);

            // Assert
            _mockService.Verify();
            var requestResult = result.Should().BeOfType<ResponseBase>().Which;
            requestResult.StatusCode.Should().Be(HttpStatusCode.OK);
            requestResult.Error.Should().BeNull();
        }

        #endregion

        #region DeleteByIdAsync

        [Fact]
        public async void Verify_DeleteByIdAsync_Returns_OKResponse()
        {
            // Arrange
            var applicationId = Guid.NewGuid();
            _mockService
                .Setup(x => x.DeleteMeasurementByIdAsync(applicationId))
                .Verifiable();

            // Act
            var result = await _testObject.DeleteByIdAsync(applicationId);

            // Assert
            _mockService.Verify();
            var requestResult = result.Should().BeOfType<ResponseBase>().Which;
            requestResult.StatusCode.Should().Be(HttpStatusCode.OK);
            requestResult.Error.Should().BeNull();
        }

        #endregion

        private void SetupMapperMock<T, K>(T input, K result)
        {
            _mockMapper
                .Setup(x => x.Map<K>(input))
                .Returns(result)
                .Verifiable();
        }
    }
}