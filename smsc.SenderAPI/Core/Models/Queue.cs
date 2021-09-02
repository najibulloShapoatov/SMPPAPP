using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Core.Models
{
    public class Queue: BaseModel
    {
        public int Priority { get; set; }
        public string Type { get; set; }
        public long MessageId { get; set; }
    }
}
