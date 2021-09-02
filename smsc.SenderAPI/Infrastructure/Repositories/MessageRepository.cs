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
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public MessageRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<List<Message>> GetByAlphanumeric(Alphanumeric alphanumeric)
        {
            return await WithConnection(async connection =>
           {
               var sqlQuery = @"SELECT * FROM messages where alphanumeric = @alphanumeric";
               var result = await connection.QueryAsync<Message>(sqlQuery, new { alphanumeric= alphanumeric.Name });
               return result.ToList();
           });
        }

        public async Task<Message> GetById(long id)
        {
            return await WithConnection(async connection =>
            {
                var sqlQuery = @"SELECT * FROM messages where id = @id";
                return await connection.QueryFirstOrDefaultAsync<Message>(sqlQuery, new { id = id });
            });
        }

        public async Task<Message> GetByIdUser(long id, long userid)
        {
            return await WithConnection(async connection =>
            {
                var sqlQuery = @"SELECT * FROM messages where id = @id and user_id=@userid";
                return await connection.QueryFirstOrDefaultAsync<Message>(sqlQuery, new { id = id, userid = userid });
            });
        }

        public async Task<List<Message>> GetByUser(User user)
        {
            return await WithConnection(async connection =>
            {
                var sqlQuery = @"SELECT * FROM messages where user_id = @user";
                var result = await connection.QueryAsync<Message>(sqlQuery, new { user=user.Id });
                return result.ToList();
            });
        }

        public async Task<Message> Insert(Message sentSms)
        {
            return await WithConnection(async connection =>
            {
                var sqlQuery = "INSERT INTO messages (status, user_id, alphanumeric,parts, phone,content,note )" +
                " VALUES(@Status, @UserId, @Alphanumeric, @Parts, @Phone,@Content, @Note) Returning *";

                return await connection.QueryFirstOrDefaultAsync<Message>(sqlQuery, sentSms);
            });
        }

        public async Task<Message> Update(Message sentSms)
        {
            return await WithConnection(async connection =>
            {
                var sqlQuery = "UPDATE messages SET status = @Status, user_id = @UserId, parts = @Parts,phone = @Phone, note = @Note  OUTPUT INSERTED.ID WHERE id = @Id";

                return await connection.QueryFirstOrDefaultAsync<Message>(sqlQuery, new { sentSms });
            });
        }
    }
}
