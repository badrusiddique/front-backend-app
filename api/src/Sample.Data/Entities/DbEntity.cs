namespace Sample.Data.Entities
{
    public abstract class DbEntity
    {
        public bool IsInactive { get; set; } = false;
    }
}