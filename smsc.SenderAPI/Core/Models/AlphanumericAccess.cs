using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Core.Models
{
    public class AlphanumericAccess:BaseModel
    {
        public long AlphanumericId { get; set; }
        public long UserId { get; set; }
    }
}
