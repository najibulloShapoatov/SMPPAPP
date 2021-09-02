using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Core.Models
{
    public class User:BaseModel
    {        
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string ApiKey { get; set; }

    }
}
