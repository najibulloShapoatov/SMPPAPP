using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Handlers.DTO
{
    public class SendGetRequest
    {
        public string key { get; set; } 
        public string src { get; set; }
        public string dst { get; set; }
        public string text { get; set; }
    }
}
