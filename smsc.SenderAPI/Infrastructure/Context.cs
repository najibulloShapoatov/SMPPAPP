using Microsoft.Extensions.Primitives;
using smsc.SenderAPI.Core.Models;
using smsc.SenderAPI.Infrastructure.Repositories;
using smsc.SenderAPI.Infrastructure.Repositories.Interfaces;
using smsc.SenderAPI.Infrastructure.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Infrastructure
{
    public class Context : IContext
    {
        public Context(IUserRepository productRepository, 
            IAlphanumericRepository alphanumericRepository, 
            IAlphanumericAccessRepository alphanumericAccessRepository, 
            IMessageRepository message,
            IMessagePartRepository messagePart, 
            IQueueRepository queue)
        {
            Users = productRepository;
            Alphanumerics = alphanumericRepository;
            AlphanumericAccesses = alphanumericAccessRepository;
            Messages = message;
            MessageParts = messagePart;
            Queues = queue;

        }
        public IUserRepository Users { get; }

        public IAlphanumericRepository Alphanumerics { get; }

        public IAlphanumericAccessRepository AlphanumericAccesses { get; }

        public IMessageRepository Messages {
            get;
        }

        public IMessagePartRepository MessageParts {
            get;
        }

        public IQueueRepository Queues { get; }

       
        //я из сделанного только это  нормально  и все это как бы  мы создали там если помниш ApplicationDbContext или типа того
    }

}
