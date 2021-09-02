using smsc.SenderAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Infrastructure.Repositories.Interfaces
{
    public interface IMessagePartRepository
    {
        Task<MessagePart> Insert(MessagePart MessagePart);
        Task<List<MessagePart>> GetByMessage(Message sentSms);    
    }
}
