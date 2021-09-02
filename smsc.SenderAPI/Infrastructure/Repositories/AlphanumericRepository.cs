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
    public class AlphanumericRepository : BaseRepository, IAlphanumericRepository
    {
        public AlphanumericRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<Alphanumeric> GetByName(string name)
        {
            return await WithConnection(async (connection) =>
            {
                var sqlQuery = @"SELECT * FROM alphanumerics where name = @name";
                return await connection.QueryFirstOrDefaultAsync<Alphanumeric>(sqlQuery, new { name });
            });
        }
    }
}
