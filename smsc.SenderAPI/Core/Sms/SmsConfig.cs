using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Core.Sms
{
    public class SmsConfig
    {
        public string host { get; set; }
        public int port { get; set; }
        public string systemId { get; set; }
        public string password { get; set; }
    }
}
