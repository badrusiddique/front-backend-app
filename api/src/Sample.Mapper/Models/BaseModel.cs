using System;

namespace Sample.Mapper.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public string RequestedBy { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}