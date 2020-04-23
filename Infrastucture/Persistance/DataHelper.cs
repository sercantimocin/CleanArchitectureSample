using Common.Model;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Persistance
{
    public class DataHelper : IDataHelper
    {
        private string _readConStr;
        private string _conStr;

        public DataHelper(IOptions<Settings> options)
        {
            _readConStr = options.Value.ReadDbConStr;
            _conStr = options.Value.DbConStr;
        }

        public IDbConnection GetOpenConnection(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public Task<int> ExecuteAsync(string sql, object param)
        {
            return Disposable.UsingAsync(() => this.GetOpenConnection(_conStr), connection => connection.ExecuteAsync(sql, param));
        }

        public Task<T> QuerySingleAsync<T>(string sql, object param)
        {
            return Disposable.Using(() => this.GetOpenConnection(_readConStr), async connection => (await connection.QueryAsync<T>(sql, param)).FirstOrDefault());
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string sql)
        {
            return Disposable.UsingAsync(() => this.GetOpenConnection(_readConStr), connection => connection.QueryAsync<T>(sql));
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string sql, object param)
        {
            return Disposable.UsingAsync(() => this.GetOpenConnection(_readConStr), connection => connection.QueryAsync<T>(sql, param));
        }
    }
}
