using Dapper;
using Microsoft.Extensions.Configuration;
using smsc.SenderAPI.Core.Models;
using smsc.SenderAPI.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Infrastructure.Repositories
{
    public class QueueRepository: BaseRepository, IQueueRepository
    {
        public QueueRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<int> Delete(Queue queue)
        {
            return await WithConnection(async connection =>
            {
                var sqlQuery = @"DELETE FROM queues WHERE id = @id";
                return await connection.ExecuteAsync(sqlQuery, new {id= queue.Id });
            });
        }

        public async Task<List<Queue>> GetQueueWithPriority()
        {
            return await WithConnection(async connection =>
            {
                var sqlQuery = @"SELECT * FROM queues order by priority asc";
                var result = await connection.QueryAsync<Queue>(sqlQuery);
                return result.ToList();
            });
        }

        public async Task<Queue> Insert(Queue queue)
        {
            return await WithConnection(async connection =>
           {
               string query = @"INSERT INTO queues (priority, type, message_id) VALUES (@priority, @type, @messageId) Returning *";
               return await connection.QueryFirstOrDefaultAsync<Queue>(query, queue);
           });
        }
    }
}
