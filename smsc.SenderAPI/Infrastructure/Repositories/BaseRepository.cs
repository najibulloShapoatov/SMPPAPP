using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace smsc.SenderAPI.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        private readonly string _connectionString;
        private readonly NpgsqlConnection _connection;
        protected BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _connection = new NpgsqlConnection(_connectionString);
        }

        // use for buffered queries that return a type
        protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            try
            {
                
                if (_connection.State != ConnectionState.Open)
                {
                    if(_connection.State!=ConnectionState.Closed)
                        await _connection.CloseAsync();
                    await _connection.OpenAsync();

                }
                return await getData(_connection);
            }
            catch (TimeoutException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
            }
            catch (NpgsqlException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
            }
        }

        // use for buffered queries that do not return a type
        protected async Task WithConnection(Func<IDbConnection, Task> getData)
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            try
            {
                await using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    await getData(connection);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
            }
            catch (NpgsqlException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
            }
        }
    }
}
