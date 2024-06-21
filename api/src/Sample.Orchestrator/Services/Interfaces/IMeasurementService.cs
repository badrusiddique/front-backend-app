using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.Mapper.DTOs.Request;
using Sample.Mapper.Models;

namespace Sample.Orchestrator.Services.Interfaces
{
    public interface IMeasurementService
    {
        ValueTask<MeasurementModel> CreateMeasurementAsync(MeasurementRequestDto requestDto);

        ValueTask<int> UpdateMeasurementByIdAsync(Guid id, MeasurementRequestDto requestDto);

        ValueTask<int> DeleteMeasurementByIdAsync(Guid id);

        ValueTask<IEnumerable<MeasurementModel>> GetAllMeasurementsAsync();

        ValueTask<MeasurementModel> GetMeasurementByIdAsync(Guid id);
    }
}