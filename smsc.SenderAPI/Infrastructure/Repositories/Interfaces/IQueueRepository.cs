using smsc.SenderAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Infrastructure.Repositories.Interfaces
{
    public interface IQueueRepository
    {
        Task<Queue> Insert(Queue queue);
        Task<List<Queue>> GetQueueWithPriority();
        Task<int> Delete(Queue queue);
    }
}
