using System;

namespace Sample.Mapper.DTOs.Request
{
    public class BaseRequestDto
    {
        /// <summary>
        /// database unique identifier
        /// </summary>
        public Guid Id { get; set; }
    }
}