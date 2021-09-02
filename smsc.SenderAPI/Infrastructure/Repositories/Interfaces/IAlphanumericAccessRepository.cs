using smsc.SenderAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Infrastructure.Repositories.Interfaces
{
    public interface IAlphanumericAccessRepository
    {
        Task<AlphanumericAccess> GetByUser(User user);
        Task<AlphanumericAccess> GetByUserAlphanumeric(Alphanumeric src, User user);
        Task<List<AlphanumericAccess>> GetByAlphanumeric();
    }
}
