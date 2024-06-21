using AutoMapper;
using Sample.Data.Entities;
using Sample.Mapper.DTOs.Request;
using Sample.Mapper.DTOs.Response;
using Sample.Mapper.Models;

namespace Sample.Mapper.Mappers
{
    public class MeasurementMapper : Profile
    {
        public MeasurementMapper()
        {
            // Database entity to Domain entity mapping
            CreateMap<Measurement, MeasurementModel>()
                .ForMember(x => x.LastUpdatedAt, y => y.MapFrom(z => z.UpdatedAt ?? z.CreatedAt));
            CreateMap<MeasurementModel, Measurement>();

            // Domain entity mapping to View DTO mapping
            CreateMap<MeasurementModel, MeasurementResponseDto>();
            CreateMap<MeasurementRequestDto, Measurement>();
        }
    }
}