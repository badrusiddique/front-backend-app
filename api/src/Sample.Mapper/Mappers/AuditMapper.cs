using AutoMapper;
using Sample.Data.Entities;
using Sample.Mapper.DTOs.Response;
using Sample.Mapper.Models;

namespace Sample.Mapper.Mappers
{
    public class AuditMapper : Profile
    {
        public AuditMapper()
        {
            // Database entity - Domain entity mapping
            CreateMap<Audit, AuditModel>()
                .ForMember(x => x.LastUpdatedAt, y => y.MapFrom(z => z.CreatedAt));

            // Domain entity mapping - View DTO mapping
            CreateMap<AuditModel, AuditResponseDto>();
        }
    }
}