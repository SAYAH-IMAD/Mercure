using Dapper;
using Microsoft.Data.SqlClient;

namespace Mercure.Common
{
    public class AccessDB : IAccessDB
    {
        readonly string _connection;

        public AccessDB(string connection)
        {
            _connection = connection;
        }

        public AccessDB ConfigureMapping() 
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
    }
}
