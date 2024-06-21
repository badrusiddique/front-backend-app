using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Sample.Common.Extensions;

namespace Sample.Data.Entities
{
    public class Audit : DbEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string State { get; set; }

        public string TableName { get; set; }

        public string KeyValues { get; set; }

        public string OldValues { get; set; }

        public string NewValues { get; set; }

        public string RequestedBy { get; set; }
    }

    [NotMapped]
    public class AuditEntry
    {
        public EntityState State { get; set; }

        public string TableName { get; set; }

        public string RequestedBy { get; set; }

        public EntityEntry EntityEntry { get; set; }

        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();

        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();

        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();

        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public Audit ToAudit() =>
            new Audit
            {
                State = State.ToString(),
                TableName = TableName,
                RequestedBy = RequestedBy,
                KeyValues = JsonConvert.SerializeObject(KeyValues),
                OldValues = OldValues.SafeEmpty() ? null : JsonConvert.SerializeObject(OldValues),
                NewValues = NewValues.SafeEmpty() ? null : JsonConvert.SerializeObject(NewValues)
            };
    }
}