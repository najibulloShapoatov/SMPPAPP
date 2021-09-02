using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Core.Models
{
    public class MessagePart:BaseModel //
    {

        public long MessageId { get; set; }
        public string Note { get; set; }
        public string OutsideId { get; set; }
    }
}
