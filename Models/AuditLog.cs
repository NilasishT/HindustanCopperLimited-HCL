using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hindustancopperlimited.Models
{
    public partial class AuditLog
    {
        public Guid AuditLogId { get; set; }
        public string UserId { get; set; }
        public string HostAddress { get; set; }
        public DateTime EventDateUTC { get; set; }
        public string EventType { get; set; }
        public string TableName { get; set; }
        public long RecordId { get; set; }
        public string ColumnName { get; set; }
        public string OriginalValue {get;set;}
        public string NewValue { get; set; }
    }
}