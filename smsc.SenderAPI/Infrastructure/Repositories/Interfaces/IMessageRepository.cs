using smsc.SenderAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Infrastructure.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task<Message> Insert(Message sentSms);
        Task<Message> Update(Message sentSms);
        Task<List<Message>> GetByAlphanumeric(Alphanumeric alphanumeric);
        Task<List<Message>> GetByUser(User user);
        Task<Message> GetByIdUser(long id, long userid);
        Task<Message> GetById(long id);
    }
}
