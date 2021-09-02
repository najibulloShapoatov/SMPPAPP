using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using smsc.SenderAPI.Core.Models;
using smsc.SenderAPI.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smsc.SenderAPI.Infrastructure.Repositories.UserRepository
{

    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration):base(configuration)
        {
            
        }



        public async Task<User> GetByApiKey(string apikey)
        {
            return await WithConnection(async (connection) =>
            {
                string sqlQuery = "SELECT * FROM users WHERE api_key = @apikey";
                return await connection.QueryFirstOrDefaultAsync<User>(sqlQuery, new { apikey });
               

            });
        }
    }

}
