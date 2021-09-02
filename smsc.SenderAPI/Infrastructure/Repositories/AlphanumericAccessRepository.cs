using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using smsc.SenderAPI.Core.Models;
using smsc.SenderAPI.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Infrastructure.Repositories
{
    public class AlphanumericAccessRepository : BaseRepository, IAlphanumericAccessRepository
    {
        public AlphanumericAccessRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<List<AlphanumericAccess>> GetByAlphanumeric()
        {
            return await WithConnection(async (connection) =>
            {
                var sqlQuery = @"SELECT * FROM alphanumeric_accesses";
                var result = await connection.QueryAsync<AlphanumericAccess>(sqlQuery);
                return result.ToList();
            });
        }

        public async Task<AlphanumericAccess> GetByUser(User user)
        {
            return await WithConnection(async (connection) =>
            {
                var sqlQuery = @"SELECT * FROM alphanumeric_accesses where user_id = @user";
                var result = await connection.QueryFirstOrDefaultAsync<AlphanumericAccess>(sqlQuery, new { user.Id });
                return result;
            });
        }

        public async Task<AlphanumericAccess> GetByUserAlphanumeric(Alphanumeric alph, User user)
        {
            return await WithConnection(async (connection) =>
            {
                var sqlQuery = @"SELECT * FROM alphanumeric_accesses where user_id = @userid and alphanumeric_id = @alphid";
                var result = await connection.QueryFirstOrDefaultAsync<AlphanumericAccess>(sqlQuery, new { userid = user.Id, alphid= alph.Id });
                return result;
            });
        }
    }
}
