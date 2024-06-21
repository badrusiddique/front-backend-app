using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.Responses;
using Sample.Api.Validators;
using Sample.Mapper.DTOs.Request;
using Sample.Mapper.DTOs.Response;
using Sample.Orchestrator.Services.Interfaces;

namespace Sample.Api.Controllers
{
    [Route("api/measurements")]
    public class MeasurementsController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMeasurementService _service;

        public MeasurementsController(IMapper mapper, IMeasurementService measurementService)
        {
            _mapper = mapper;
            _service = measurementService;
        }

        /// <summary>
        /// Get all measurement information
        /// </summary>
        /// <remarks>
        ///
        ///     GET /api/measurements
        ///
        /// </remarks>
        /// <returns>measurement Response Dto</returns>
        [HttpGet]
        public async ValueTask<ApiResponse<IEnumerable<MeasurementResponseDto>>> GetAllAsync()
        {
            var models = await _service.GetAllMeasurementsAsync();
            var measurements = _mapper.Map<IEnumerable<MeasurementResponseDto>>(models);
            return ApiResponse<IEnumerable<MeasurementResponseDto>>.ParseResponse(measurements);
        }

        /// <summary>
        /// Gets measurement information by measurement id
        /// </summary>
        /// <remarks>
        ///
        ///     GET /api/measurements/{id}
        ///
        /// </remarks>
        /// <param name="id">measurement unique identifier</param>
        /// <returns>measurement Response Dto</returns>
        [ValidationFilter]
        [HttpGet("{id}")]
        public async ValueTask<ApiResponse<MeasurementResponseDto>> GetByIdAsync(Guid id)
        {
            var model = await _service.GetMeasurementByIdAsync(id);
            var measurement = _mapper.Map<MeasurementResponseDto>(model);
            return ApiResponse<MeasurementResponseDto>.ParseResponse(measurement);
        }

        /// <summary>
        /// Creates a measurement record
        /// </summary>
        /// <remarks>
        ///   Note -
        ///
        ///     POST /api/measurements
        ///     {
        ///     "email": "email address",
        ///     "name": "user name",
        ///     "state": "state one of - Startup, Slow, Running, Stopping, Shutdown",
        ///     "speed": speed value,
        ///     "vibration": vibration value,
        ///     "acceleration": acceleration value optional,
        ///     "temperature": temperature value,
        ///     }
        ///
        /// </remarks>
        /// <returns>Measurement Response Dto</returns>
        [HttpPost]
        public async ValueTask<ApiResponse<MeasurementResponseDto>> CreateAsync(MeasurementRequestDto requestDto)
        {
            var model = await _service.CreateMeasurementAsync(requestDto);
            var measurement = _mapper.Map<MeasurementResponseDto>(model);
            return ApiResponse<MeasurementResponseDto>.ParseResponse(measurement);
        }

        /// <summary>
        /// Updates a measurement record
        /// </summary>
        /// <remarks>
        ///
        ///     PUT /api/measurements
        ///     {
        ///     "email": "email address",
        ///     "name": "user name",
        ///     "state": "state one of - Startup, Slow, Running, Stopping, Shutdown",
        ///     "speed": speed value,
        ///     "vibration": vibration value,
        ///     "acceleration": acceleration value optional,
        ///     "temperature": temperature value,
        ///     }
        ///
        /// </remarks>
        /// <param name="id">measurement unique identifier</param>
        /// <param name="requestDto"></param>
        /// <returns>Response Dto</returns>
        [ValidationFilter]
        [HttpPut("{id}")]
        public async ValueTask<ResponseBase> UpdateByIdAsync(Guid id, MeasurementRequestDto requestDto)
        {
            await _service.UpdateMeasurementByIdAsync(id, requestDto);
            return ResponseBase.DefaultResponse();
        }

        /// <summary>
        /// Removes a measurement record
        /// </summary>
        /// <remarks>
        ///
        ///     DELETE /api/measurements/{id}
        ///
        /// </remarks>
        /// <param name="id">measurement unique identifier</param>
        /// <returns></returns>
        [ValidationFilter]
        [HttpDelete("{id}")]
        public async ValueTask<ResponseBase> DeleteByIdAsync(Guid id)
        {
            await _service.DeleteMeasurementByIdAsync(id);
            return ResponseBase.DefaultResponse();
        }
    }
}