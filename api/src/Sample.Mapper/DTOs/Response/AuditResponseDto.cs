namespace Sample.Mapper.DTOs.Response
{
    /// <summary>
    /// audit response data transformation object
    /// </summary>
    public class AuditResponseDto : BaseResponseDto
    {
        public string State { get; set; }
        public string TableName { get; set; }
        public string RequestedBy { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
    }
}