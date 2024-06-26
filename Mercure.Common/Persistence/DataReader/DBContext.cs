﻿using Dapper;
using Microsoft.Data.SqlClient;
using static Dapper.SqlMapper;

namespace Mercure.Common.Persistence.DataReader
{
    public class DBContext : IDBContext
    {
        readonly string _connection;

        public DBContext(string connection)
        {
            _connection = connection;
        }

        public DBContext ConfigureMapping()
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            return this;
        }

        public void Execute<T>(string query, Dictionary<string, object> parameters)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Execute(query, parameters);
            }
        }

        public void Execute(string query, Dictionary<string, object> parameters)
        {
            using (var connection = new SqlConnection(_connection))
            {
                connection.Execute(query, parameters);
            }
        }

        public long GetSequence(string sequence)
        {
            using (var connection = new SqlConnection(_connection))
            {
                return connection.ExecuteScalar<long>($"SELECT NEXT VALUE FOR {sequence}");
            }
        }

        public IEnumerable<T> Read<T>(string query, Dictionary<string, object> parameters)
        {
            using (var connection = new SqlConnection(_connection))
            {
                return connection.Query<T>(query, parameters);
            }
        }

        public T ReadFirst<T>(string query, Dictionary<string, object> parameters)
        {
            using (var connection = new SqlConnection(_connection))
            {
                return connection.QueryFirstOrDefault<T>(query, parameters);
            }
        }

        public T QueryMultiple<T>(string query, Dictionary<string, object> parameters, Func<GridReader,T> converter)
        {
            using (var connection = new SqlConnection(_connection))
            {
                using (var multiple = connection.QueryMultiple(query, parameters))
                {
                    return converter.Invoke(multiple);
                }
            }
        }
    }
}
