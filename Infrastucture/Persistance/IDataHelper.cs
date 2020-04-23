using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Persistance
{
    public interface IDataHelper
    {
        IDbConnection GetOpenConnection(string connectionString);
        Task<int> ExecuteAsync(string sql, object param);
        Task<T> QuerySingleAsync<T>(string sql, object param);
        Task<IEnumerable<T>> QueryAsync<T>(string sql);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param);
    }
}
