namespace Sample.Mapper.Models
{
    public class AuditModel : BaseModel
    {
        public string State { get; set; }
        public string TableName { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
    }
}