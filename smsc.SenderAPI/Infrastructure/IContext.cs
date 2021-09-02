using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using smsc.SenderAPI.Core.Models;
using smsc.SenderAPI.Infrastructure.Repositories;
using smsc.SenderAPI.Infrastructure.Repositories.Interfaces;
using smsc.SenderAPI.Infrastructure.Repositories.UserRepository;

namespace smsc.SenderAPI.Infrastructure
{

    public interface IContext
    {
        IUserRepository Users { get; }
        IAlphanumericRepository Alphanumerics { get; }
        IAlphanumericAccessRepository AlphanumericAccesses { get; }
        IMessageRepository Messages { get; }
        IMessagePartRepository MessageParts { get; }
        IQueueRepository Queues { get; }
    }
}
