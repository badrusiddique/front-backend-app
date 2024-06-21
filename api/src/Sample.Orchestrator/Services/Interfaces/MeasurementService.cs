using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
using Sample.Data.Entities;
using Sample.Mapper.DTOs.Request;
using Sample.Mapper.Models;
using Sample.Orchestrator.Repositories.Interfaces;

namespace Sample.Orchestrator.Services.Interfaces
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Measurement> _repository;

        public MeasurementService(IRepository<Measurement> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

    public async ValueTask<MeasurementModel> CreateMeasurementAsync(MeasurementRequestDto requestDto)
        {
            EnsureArg.IsNotNull(requestDto, nameof(requestDto), o => o.WithMessage($"cannot process invalid measurement input: {requestDto}"));

            var entity = _mapper.Map<Measurement>(requestDto);
            var createdEntity = await _repository.CreateAndSaveAsync(entity);

            return _mapper.Map<MeasurementModel>(createdEntity);
        }

        public async ValueTask<int> UpdateMeasurementByIdAsync(Guid id, MeasurementRequestDto requestDto)
        {
            EnsureArg.IsNotDefault(id, nameof(id));
            EnsureArg.IsNotNull(requestDto, nameof(requestDto), o => o.WithMessage($"cannot process invalid measurement input: {requestDto}"));

            requestDto.Id = id;
            var measurement = await ParseMeasurementEntityByAsync(requestDto);

            return await _repository.UpdateAndSaveAsync(measurement);
        }

        public async ValueTask<int> DeleteMeasurementByIdAsync(Guid id)
        {
            EnsureArg.IsNotDefault(id, nameof(id));

            var measurement = await _repository.FindAsync(id);

            if (measurement == null) { return default; }

            return await _repository.DeleteAndSaveAsync(measurement);
        }

        public async ValueTask<IEnumerable<MeasurementModel>> GetAllMeasurementsAsync()
        {
            var measurements = await _repository
                .All()
                .ToListAsync();

            return _mapper.Map<IEnumerable<MeasurementModel>>(measurements);
        }

        public async ValueTask<MeasurementModel> GetMeasurementByIdAsync(Guid id)
        {
            EnsureArg.IsNotDefault(id, nameof(id));

            var measurement = await _repository.FindAsync(id);

            return _mapper.Map<MeasurementModel>(measurement);
        }

        private async ValueTask<Measurement> ParseMeasurementEntityByAsync(MeasurementRequestDto model)
        {
            var measurement = await VerifyAndGetMeasurementByIdAsync(model.Id);

            measurement.Name = model.Name ?? measurement.Name;
            measurement.Email = model.Email ?? measurement.Email;
            measurement.State = model.State ?? measurement.State;
            measurement.Acceleration = model.Acceleration ?? measurement.Acceleration;
            measurement.Speed = model.Speed == default ? measurement.Speed : model.Speed;
            measurement.Vibration = model.Vibration == default ? measurement.Vibration : model.Vibration;
            measurement.Temperature = model.Temperature == default ? measurement.Temperature : model.Temperature;

            return measurement;
        }

        private async ValueTask<Measurement> VerifyAndGetMeasurementByIdAsync(Guid id)
        {
            var measurement = await _repository.FindAsync(id);
            EnsureArg.IsNotNull(measurement, nameof(measurement), o => o.WithMessage($"cannot find resource with id: {id}"));

            return measurement;
        }
    }
}