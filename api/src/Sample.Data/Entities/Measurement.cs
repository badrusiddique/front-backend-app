using System.ComponentModel.DataAnnotations;

namespace Sample.Data.Entities
{
    public class Measurement : BaseEntity
    {
        public string State { get; set; }
        [Range(0, 10000)]
        public int Speed { get; set; }
        [Range(0, 300)]
        public double Vibration { get; set; }
        [Range(-50, 50)]
        public double? Acceleration { get; set; }
        [Range(0, 1000)]
        public double Temperature { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}