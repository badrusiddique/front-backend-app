namespace Sample.Mapper.DTOs.Response
{
    public class MeasurementResponseDto : BaseResponseDto
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