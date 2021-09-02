using Dapper;
using Microsoft.AspNetCore.Mvc;
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
    public class MessagePartRepository : IMessagePartRepository
    {
        private readonly IConfiguration configuration;
        private readonly string conf;
        public MessagePartRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.conf = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<MessagePart>> GetByMessage(Message message)
        {
            using (var connection = new NpgsqlConnection(conf))
            {
                var sqlQuery = @"SELECT * FROM message_parts where message_id = @sentSms";
                var result = await connection.QueryAsync<MessagePart>(sqlQuery, new { message.Id });
                return result.ToList();
            }
        }

        public async Task<MessagePart> Insert(MessagePart MessagePart) 
        {
            using (var connection = new NpgsqlConnection(conf))
            {
                var sqlQuery = @"INSERT INTO message_parts (message_id, note, outside_id)
                                 VALUES(@MessageId, @Note, @OutsideId) Returning *";

                return await connection.QueryFirstOrDefaultAsync<MessagePart>(sqlQuery, MessagePart);
            }
        }
    }
}
