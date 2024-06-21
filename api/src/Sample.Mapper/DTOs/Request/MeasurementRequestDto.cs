namespace Sample.Mapper.DTOs.Request
{
    /// <summary>
    /// application request data transformation object
    /// </summary>
    public class MeasurementRequestDto : BaseRequestDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public int Speed { get; set; }
        public double Vibration { get; set; }
        public double? Acceleration { get; set; }
        public double Temperature { get; set; }
    }
}