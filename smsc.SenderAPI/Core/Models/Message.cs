using smsc.SenderAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Core.Models
{
    public class Message:BaseModel
    {
        public int Status { get; set; }
        public long UserId { get; set; }
        public string Alphanumeric { get; set; }
        public int Parts { get; set; }
        public string Phone { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }
        public DateTime ScheduledAt { get; set; }
        public DateTime SentAt { get; set; }
    }
}
