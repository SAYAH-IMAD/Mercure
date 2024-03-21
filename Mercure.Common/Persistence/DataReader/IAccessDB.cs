using static Dapper.SqlMapper;

namespace Mercure.Common.Persistence.DataReader
{
    public interface IAccessDB
    {
        long GetSequence(string query);
        void Execute<T>(string query, Dictionary<string, object> parameters);
        void Execute(string query, Dictionary<string, object> parameters);
        IEnumerable<T> Read<T>(string query, Dictionary<string, object> parameters);
        T ReadFirst<T>(string query, Dictionary<string, object> parameters);
        T QueryMultiple<T>(string query, Dictionary<string, object> parameters, Func<GridReader, T> converter);
    }
}
