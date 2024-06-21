using System;

namespace Sample.Mapper.DTOs.Response
{
    public class BaseResponseDto
    {
        public Guid Id { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}